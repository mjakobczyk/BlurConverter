.DATA

	min				byte		0
	max				byte		255
	szerokosc		dw			0
	wysokosc		dw			0
	nastepny		dd			3
	suma			dd			0
	ilosc			dd			0
	tab_y			dd			0
	tab_x			dd			0
	ELEMENTS		equ			9

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

		xor r10, r10				; Zerujemy rejestr r10
		mov r10d, dword ptr[rbp+48]; Do rejestru wpisujemy wartosc promienia
		add r10d, dword ptr[rbp+48]; Dodajemy wartosc promienia dwa razy zeby uzyskac 3*promien
		add r10d, dword ptr[rbp+48]; Bedzie to potrzebne do wyznaczenia warunku startu i stopu

		mov rbx, r10				; rbx jest offsetem, ktory sluzy do poruszania sie po tablicach
									; Indeksowanie rozpoczynamy od 0, wiec umieszczamy tam 0

		mov r11, rcx				; Zapisz szerokosc bitmapy do rejestru r11

		mov szerokosc, cx			; Zapisz szerokosc bitmapy do zmiennej

		mov wysokosc, dx			; Zapisz wysoksc bitmapy do zmiennej wysokosc
									
		sub rcx, r10				; Odejmujemy 3x promien, bo nie bedziemy dochodzi do krawedzi

		push rsi					; Zachowaj wartosc rejestru RSI na stosie
		push rdi					; Zachowaj wartosc rejestru RDI na stosie
		push r12					; Zachowaj wartosc rejestru R12 na stosie
		push r13					; Zachowaj wartosc rejestru R13 na stosie
		push r14					; Zachowaj wartosc rejestru R14 na stosie
		push r15					; Zachowaj wartosc rejestru R15 na stosie

		xor rsi, rsi				; Wyczysc rejestr rsi
		mov rsi, r8					; Ustaw rejestr rsi jako pocz¹tek wiersza pikseli

		xor rdi, rdi				; Wyczysc rejestr rdi
		mov rdi, r9					; Ustaw rejestr rdi jako poczatek tablicy pikseli


wiersz_petla:						; Etykieta glownej petli

		xor r10, r10											; Wyczysc rejestr r10 przed uzyciem
		movzx r10, byte ptr [rdi + rbx - 3]						; Pobierz piksel z tablicy wpisujac go do r10
		xorpd xmm0, xmm0										; Wyczysc rejestr XMM0
		cvtsi2sd xmm0, r10										; Skonweruj inta na flota i wpisz do xmm1
		
		xor r10, r10											; Wyczysc rejestr r10 przed uzyciem
		movzx r10, byte ptr [rdi + rbx]							; Pobierz piksel z tablicy wpisujac go do r10
		xorpd xmm1, xmm1										; Wyczysc rejestr XMM1
		cvtsi2sd xmm1, r10										; Skonweruj inta na flota i wpisz do xmm1
		addsd xmm0, xmm1										; Wykorzystaj instrukcje SSE2 i dodaj do siebie xmm

		xor r10, r10											; Wyczysc rejestr r10 przed uzyciem
		movzx r10, byte ptr [rdi + rbx + 3]						; Pobierz piksel z tablicy wpisujac go do r10
		xorpd xmm2, xmm2										; Wyczysc rejestr XMM2
		cvtsi2sd xmm2, r10										; Skonweruj inta na flota i wpisz do xmm1
		addsd xmm0, xmm2										; Wykorzystaj instrukcje SSE2 i dodaj do siebie xmm

		xor r10, r10											; Wyczysc rejestr r10 przed uzyciem
		movzx r10, byte ptr [rdi + rbx + 4800 - 3]				; Pobierz piksel z tablicy wpisujac go do r10
		xorpd xmm3, xmm3										; Wyczysc rejestr XMM3
		cvtsi2sd xmm3, r10										; Skonweruj inta na flota i wpisz do xmm1
		addsd xmm0, xmm3										; Wykorzystaj instrukcje SSE2 i dodaj do siebie xmm

		xor r10, r10											; Wyczysc rejestr r10 przed uzyciem
		movzx r10, byte ptr [rdi + rbx + 4800 + 3]				; Pobierz piksel z tablicy wpisujac go do r10
		xorpd xmm4, xmm4										; Wyczysc rejestr XMM4
		cvtsi2sd xmm4, r10										; Skonweruj inta na flota i wpisz do xmm1
		addsd xmm0, xmm4										; Wykorzystaj instrukcje SSE2 i dodaj do siebie xmm

		xor r10, r10											; Wyczysc rejestr r10 przed uzyciem
		movzx r10, byte ptr [rdi + rbx + 4800 + 4800 - 3]		; Pobierz piksel z tablicy wpisujac go do r10
		xorpd xmm5, xmm5										; Wyczysc rejestr XMM5
		cvtsi2sd xmm5, r10										; Skonweruj inta na flota i wpisz do xmm1
		addsd xmm0, xmm5										; Wykorzystaj instrukcje SSE2 i dodaj do siebie xmm

		xor r10, r10											; Wyczysc rejestr r10 przed uzyciem
		movzx r10, byte ptr [rdi + rbx + 4800 + 4800]			; Pobierz piksel z tablicy wpisujac go do r10
		xorpd xmm6, xmm6										; Wyczysc rejestr XMM6
		cvtsi2sd xmm6, r10										; Skonweruj inta na flota i wpisz do xmm1
		addsd xmm0, xmm6										; Wykorzystaj instrukcje SSE2 i dodaj do siebie xmm

		xor r10, r10											; Wyczysc rejestr r10 przed uzyciem
		movzx r10, byte ptr [rdi + rbx + 4800 + 4800 + 3]		; Pobierz piksel z tablicy wpisujac go do r10
		xorpd xmm7, xmm7										; Wyczysc rejestr XMM7
		cvtsi2sd xmm7, r10										; Skonweruj inta na flota i wpisz do xmm1
		addsd xmm0, xmm7										; Wykorzystaj instrukcje SSE2 i dodaj do siebie xmm

		xor r10, r10											; Wyczysc rejestr r10 przed uzyciem
		movzx r10, byte ptr [rdi + rbx + 4800]					; Pobierz piksel z tablicy wpisujac go do r10
		xorpd xmm1, xmm1										; Wyczysc rejestr XMM1
		cvtsi2sd xmm1, r10										; Skonweruj inta na flota i wpisz do xmm1
		addsd xmm0, xmm1										; Wykorzystaj instrukcje SSE2 i dodaj do siebie xmm

		xor r12, r12											; Wyczysc rejestr r12 przed uzyciem
		mov r12, ELEMENTS										; Do rejestru r12 wpisz ilosc elementow do podzielenia
		xorpd xmm2, xmm2										; Wyczysc rejestr XMM2
		cvtsi2sd xmm2, r12										; Skonweruj inta na flota i wpisz do xmm2
		divsd xmm0, xmm2

		xor rax, rax											; Wyczysc rejestr rax przed uzyciem
		cvttsd2si  rax, xmm0;

sprawdz_max:						; Etykieta do sprawdzenia czy piksel nie przekroczyl maksymalnej wartosci

		cmp al, max					; Porownaj wartosc piksela z maksymalna wartoscia okreslona w zmiennej max
		jb sprawdz_min				; Jezeli jest niewieksza to skocz do etykiety sprawdzenia wartosci maksymalnej
		mov al, max					; Jezeli jest wieksza to przydziel pikselowi maksymalna mozliwa wartosc

sprawdz_min:						; Etykieta do sprawdzenia czy piksel nie przekroczyl minimalnej wartosci

		cmp al, min					; Porownaj wartosc piksela z minimalna wartoscia okreslona w zmiennej min
		ja zapisz					; Jezeli jest wieksza to skocz do etykiety zapisu piksela do wiersza
		mov al, min					; Jezeli jest mniejsza to przydziel pikselowi minimalna mozliwa wartosc

zapisz:

		mov byte ptr [rsi+rbx], al	; Zapisz piksel

wiersz_dalej:

		inc rbx						; Zwieksz wartosc offsetu w rejestrze rbx o 1
		dec rcx						; Zmniejsz szerokosc bitmapy do przejscia
		mov rax, rcx				; Do rejestru rax wloz szerokosc zeby sprawdzic skok
		jnz wiersz_petla			; Dopoki szerokosc nie bedzie 0 to skocz do nastepnego piksela z wierszu

koniec:

		pop r15						; Pobierz wartosc rejestru R15 ze stosu
		pop r14						; Pobierz wartosc rejestru R14 ze stosu
		pop r13						; Pobierz wartosc rejestru R13 ze stosu
		pop r12						; Pobierz wartosc rejestru R12 ze stosu
		pop rdi						; Pobierz wartosc rejestru RDI ze stosu
		pop rsi						; Pobierz wartosc rejestru RSI ze stosu


ret									; Powrot z podprogramu

BlurTransformRowASM endp
END

;-------------------------------------------------------------------------