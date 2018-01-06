.DATA

	min			byte	0
	max			byte	255
	szerokosc	dw		0
	wysokosc	dw		0
	nastepny	dd		3
	suma		dd		0
	ilosc		dd		0
	tab_y		dd		0
	tab_x		dd		0

.CODE
BlurTransformRowASM proc

; Argumenty, ktore przyjmuje funkcja:
; RCX				  - szerokosc bitmapy
; RDX				  - wysokosc bitmapy tablicy pikseli otaczajacych wiersz
; R8				  - wskaznik na pierwszy element zmienianego wiersza
; R9				  - wskaznik do tablicy pikseli otaczajacych wiersz
; DWORD PTR[rbp + 48] - promien wskazujacy obszar pikseli

start:								; Etykieta rozpoczecia funkcji, odlozenie na stos wartosci,
									; inicjalizacja licznika

		push rbx					; Zachowaj wartosc rejestru rbx na stosie
		push rbp					; Zachowaj wartosc rejestru rbp na stosie
		push rsi					; Zachowaj wartosc rejestru RSI na stosie
		push rdi					; Zachowaj wartosc rejestru RDI na stosie
		push r12					; Zachowaj wartosc rejestru R12 na stosie
		push r13					; Zachowaj wartosc rejestru R13 na stosie
		push r14					; Zachowaj wartosc rejestru R14 na stosie
		push r15					; Zachowaj wartosc rejestru R15 na stosie

		xor r10, r10				; Zerujemy rejestr r10
		mov r10d, dword ptr[rbp+48] ; Do rejestru wpisujemy wartosc promienia
		add r10d, dword ptr[rbp+48] ; Dodajemy wartosc promienia dwa razy zeby uzyskac 3*promien
		add r10d, dword ptr[rbp+48] ; Bedzie to potrzebne do wyznaczenia warunku startu i stopu

		mov rbx, r10				; rbx jest offsetem, ktory sluzy do poruszania sie po tablicach
									; Indeksowanie rozpoczynamy od 0, wiec umieszczamy tam 0

		mov r15, rcx				; Zapisz szerokosc bitmapy do rejestru r15 ------- R11 -> R15

		mov szerokosc, cx			; Zapisz szerokosc bitmapy do zmiennej

		mov wysokosc, dx			; Zapisz wysokosc bitmapy do zmiennej wysokosc
									
		push rdx					; Odloz wartosc rejestru rdx na stos
		sub rcx, r10				; Odejmujemy 3x promien, bo nie bedziemy dochodzili do krawedzi
		sub rcx, r10
		pop rdx						; Pobierz wartosc rejestru rdx ze stosu

		xor rsi, rsi				; Wyczysc rejestr rsi
		mov rsi, r8					; Ustaw rejestr rsi jako pocz¹tek wiersza pikseli

		xor rdi, rdi				; Wyczysc rejestr rdi
		mov rdi, r9					; Ustaw rejestr rdi jako poczatek tablicy pikseli

		xorps xmm7, xmm7			; Wyczysc rejestr XMM7
		;mov rbx, 12BCh

wiersz_petla:						; Etykieta glownej petli

		;xor	rax, rax			; Wyczysc rejestr RAX
		;mov al, byte ptr [rsi+rbx]	; Do najnizszej polowki rejestru rax wrzuc aktualny piksel z wiersza

		xor r11, r11				; Przygotuj rejestr r11 do przeiterowania po wszystkich wierszach

		xorps xmm7, xmm7			; Dla kazdego piksela z wiersza zresetuj rejestr sumy xmm7


tablica_y:

		xor r14, r14				; Rejestr r14 posluzy do obliczenia offsetu w tablicy pikseli
		xor rax, rax				; Wyczysc rejestr rax
		mov rax, r15				; Do offsetu dodaj szerokosc bitmapy zapisana w rejestrze r15
		push rdx					; Odloz rdx na stos przez operacje mnozenia
		mul r11						; Mnozymy razy aktualny numer kolumny tablicy pikseli, wynik zapisany w rdx
		mov r14, rax				; Do rejestru r14 zapisz wartosc z rejestru rax
		sub r14, r10				; Przesun sie o promien w lewo, zeby moc swobodnie odwolac sie do dodatnich wartosci tablicy
		pop rdx						; Zdejmij ze stosu rdx
		add r14, rbx				; Dodaj offset wiersza glownego

		xor r12, r12				; Przygotuj rejestr r12 do przeiterowania po wszystkich pikselach wiersza

tablica_x:

		xor rax, rax				; Wyczysc rejest rax

		mov al, byte ptr[rdi + r14]; Do najnizszej polowki rejestru r10 wrzucamy aktualny piksel z wiersza

		xorps xmm0, xmm0			; Wyczysc rejestr XMM0

		cvtsi2ss xmm0, eax			; Zamien typ int na float odpowiednim rozkazem i umiesc go w xmm0
									; CVTSI2SS — Convert Dword Integer to Scalar Single-Precision FP Value

		addss xmm7, xmm0			; Dodaj do siebie obydwa wektory

		xor r13, r13
		cvttss2si r13, xmm7;		; Zamien typ float na int odpowiednim rozkazem i umiesc go w rax
									; CVTTSS2SI — Convert with Truncation Scalar Single-Precision FP Value to Dword Integer

tablica_x_dalej:
	
		inc r12						; Zinkrementuj licznik pikseli w wierszu
		add r14, 3h
		cmp r12w, dx				; Porownaj licznik pikseli w wierszu z maksymalna dlugoscia wiersza
		jb tablica_x				; Jezeli jest mniejszy to skocz do nastepnego wiersza
		jb tablica_y_dalej			; Jezeli jest niemniejszy to przejdz do kolejnego wiersza

tablica_y_dalej:

		inc r11						; Zinkrementuj licznik kolumn
		cmp r11w, dx				; Porownaj licznik kolumn z maksymalna iloscia wierszy
		jb tablica_y				; Jezeli jest mniejszy to skocz do nastepnego wiersza
		jb analizuj					; Jezeli jest niemniejszy to przejdz do analizy sumy

analizuj:
		
		xor r12, r12				; Wyczysc rejestr r12
		mov r12, r13				; Do przeanalizowania piksela przenies go z r13 do r12
		cmp r12b, min				; Porownaj wartosc piksela z minimalna wartoscia
		ja podziel					; Jezeli jest wieksza to przejdz do procedury dzielenia
		xor r12, r12				; Jezeli nie, to wyczysc najpierw rejestr r12
		mov r12, 0h					; Nastepnie do rejestru r12 umiesc jedynke

podziel:

		xor r13, r13
		cvttss2si r13, xmm7;		; Zamien typ float na int odpowiednim rozkazem i umiesc go w rax

		xor rax, rax				; Wyczysc rejestr rax
		mov ax, dx					; Do rejestru rax wprowadz wysokosc tablicy pikseli
		xorps xmm1, xmm1			; Wyczysc rejestr xmm1
		cvtsi2ss xmm1, r13d			; Do rejestru xmm1 zaladuj otrzymana sume pikseli

		xorps xmm2, xmm2			; Wyczysc rejestr xmm2
		cvtsi2ss xmm2, eax			; Zamien typ int na float odpowiednim rozkazem i umiesc go w xmm1
		mulss xmm2, xmm2			; Wylicz ilosc elementow, czyli ( wysokosc tablicy ) ^2
		divss xmm1, xmm2

		xor rax, rax				; Wyczysc rejestr rax
		cvtss2si rax, xmm1			; Przeniesc wynik do najnizszej czesci rejestru rax

sprawdz_min:						; Etykieta do sprawdzenia czy piksel nie przekroczyl minimalnej wartosci

		cmp al, max					; Porownaj wartosc piksela z maksymalna wartoscia okreslona w zmiennej max
		jna sprawdz_max				; Jezeli jest niewieksza to skocz do etykiety sprawdzenia wartosci maksymalnej
		mov al, max					; Jezeli jest wieksza to przydziel pikselowi maksymalna mozliwa wartosc

sprawdz_max:						; Etykieta do sprawdzenia czy piksel nie przekroczyl maksymalnej wartosci

		cmp al, min					; Porownaj wartosc piksela z minimalna wartoscia okreslona w zmiennej min
		ja zapisz					; Jezeli jest wieksza to skocz do etykiety zapisu piksela do wiersza
		mov al, min					; Jezeli jest mniejsza to przydziel pikselowi minimalna mozliwa wartosc

		
zapisz:

		;add al, 15
		mov byte ptr [rsi+rbx], al	; Zapisz piksel

wiersz_dalej:

		inc rbx						; Zwieksz wartosc offsetu w rejestrze rbx o 1
		cmp rbx, rcx				; Porownaj offset rbx z szerokoscia wiersza rcx
		jb wiersz_petla				; Jezeli rbx <= rcx to skocz do nastepnej iteracji
		jmp koniec					; Jezeli nie to koniec obliczen

		;dec rcx					; Zmniejsz szerokosc bitmapy do przejscia
		;mov rax, rcx				; Do rejestru rax wloz szerokosc zeby sprawdzic skok
		;jnz wiersz_petla			; Dopoki szerokosc nie bedzie 0 to skocz do nastepnego piksela z wierszu

koniec:

		pop r15						; Pobierz wartosc rejestru R15 ze stosu
		pop r14						; Pobierz wartosc rejestru R14 ze stosu
		pop r13						; Pobierz wartosc rejestru R13 ze stosu
		pop r12						; Pobierz wartosc rejestru R12 ze stosu
		pop rdi						; Pobierz wartosc rejestru RDI ze stosu
		pop rsi						; Pobierz wartosc rejestru RSI ze stosu
		pop rbp						; Pobierz wartosc rejestru rbp ze stosu
		pop rbx						; Pobierz wartosc rejestru rbx ze stosu

ret

BlurTransformRowASM endp
END
;-------------------------------------------------------------------------