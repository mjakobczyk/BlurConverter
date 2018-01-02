.DATA
	max			dd		255
	min			dd		0
	nastepny	dd		3
	suma		dd		0
	ilosc		dd		0

.CODE
BlurTransformRowASM proc

; Argumenty, ktore przyjmuje funkcja:
; RCX				  - szerokosc bitmapy
; RDX				  - wysokosc bitmapy tablicy pikseli otaczajacych wiersz
; R8				  - promien wskazujacy obszar pikseli
; R9				  - wskaznik na pierwszy element zmienianego wiersza
; DWORD PTR[rbp + 48] - wskaznik do tablicy pikseli otaczajacych wiersz

start:								; Etykieta rozpoczecia funkcji

		mov rbx, 0					; rbx jest offsetem, ktory sluzy do poruszania sie po tablicach
									; Indeksowanie rozpoczynamy od 0, wiec umieszczamy tam 0

		push rsi					; Zachowaj wartosc rejestru RSI na stosie
		push rdi					; Zachowaj wartosc rejestru RDI na stosie
		push r12					; Zachowaj wartosc rejestru R12 na stosie
		push r13					; Zachowaj wartosc rejestru R13 na stosie
		push r14					; Zachowaj wartosc rejestru R14 na stosie
		push r15					; Zachowaj wartosc rejestru R15 na stosie

		;mov rsi, r9					; Ustaw rejestr RSI jako pocz¹tek wiersza pixeli


wiersz_petla:						; Etykieta glownej petli

		xorps xmm0, xmm0			; Wyczysc rejestr XMM0
		xorps xmm1, xmm1			; Wyczysc rejestr XMM1
		xorps xmm2, xmm2			; Wyczysc rejestr XMM2
		xorps xmm3, xmm3			; Wyczysc rejestr XMM3
		xorps xmm4, xmm4			; Wyczysc rejestr XMM4
		xorps xmm5, xmm5			; Wyczysc rejestr XMM5
		xorps xmm6, xmm6			; Wyczysc rejestr XMM6
		xorps xmm7, xmm7			; Wyczysc rejestr XMM7

		xor	rax, rax				; Wyczysc rejestr RAX
		mov al, byte ptr [r9+rbx]	; Do najnizszej polowki rejestru rax wrzuc aktualny piksel z wiersza


		cvtsi2ss xmm0, eax			; Zamien typ int na double odpowiednim rozkazem i umiesc go w xmm0
									; CVTSI2SS — Convert Dword Integer to Scalar Single-Precision FP Value

									; TODO
									; TUtaj ma miejsce wlasciwy algorytm tego, co sie bedzie dzialo po tym,
									; jak w xmm0 umiescimy juz piksel

		cvttss2si rax, xmm0;		;
									; CVTTSS2SI — Convert with Truncation Scalar Single-Precision FP Value to Dword Integer
		
		mov rax, 150
		
		mov byte ptr [r9+rbx], al	; Zapisz piksel

		add rbx, 1
		dec rcx
		mov rax, rcx
		jnz wiersz_petla

koniec:

		pop r15						; Pobierz wartosc rejestru R15 ze stosu
		pop r14						; Pobierz wartosc rejestru R14 ze stosu
		pop r13						; Pobierz wartosc rejestru R13 ze stosu
		pop r12						; Pobierz wartosc rejestru R12 ze stosu
		pop rdi						; Pobierz wartosc rejestru RDI ze stosu
		pop rsi						; Pobierz wartosc rejestru RSI ze stosu


ret

BlurTransformRowASM endp
END
;-------------------------------------------------------------------------
