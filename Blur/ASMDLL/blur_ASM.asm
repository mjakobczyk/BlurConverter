.DATA

	min			byte	0
	max			byte	255
	arr_width	dw		0
	arr_height	dw		0
	next		dd		3
	sum			dd		0
	count		dd		0
	tab_y		dd		0
	tab_x		dd		0

.CODE

BlurTransformRowASM proc

; Function argumments
; RCX								width of bitmap
; RDX								height of bitmap
; R8								pointer to the first element of row to be modified
; R9								pointer to the array of pixels around the row to be modified
; DWORD PTR[rbp + 48]				radius of blur

start:								; Start of the function

									; Store registers' values on stack
		push rbx
		push rbp
		push rsi
		push rdi
		push r12
		push r13
		push r14
		push r15

		xor r10, r10				; Clear r10 value
		mov r10d, dword ptr[rbp+48] ; Write radius value into register
		add r10d, dword ptr[rbp+48] ; Add radius 2 more times to obtain 3*radius value
		add r10d, dword ptr[rbp+48] ; It will be required to set start and end value

		mov rbx, r10				; rbx is an offset which is used to iterate through arrays
									; Indexing starts from 0 so 0 is passed to rbx

		mov r15, rcx				; Store width of bitmap to r15

		mov arr_width, cx			; Store bitmap width to variable

		mov arr_height, dx			; Store bitmap height to variable
									
		push rdx					; Store rdx on stack
		sub rcx, r10				; Subtract 2*radius because borders will not be analyzed
		sub rcx, r10
		pop rdx						; Get rdx from stack

		xor rsi, rsi				; Clear rsi value
		mov rsi, r8					; Set rsi as a pointer to the first element of row to be modified

		xor rdi, rdi				; Clear dxi value
		mov rdi, r9					; Set rdi as a pointer to the array of pixels around the row to be modified

		xorps xmm7, xmm7			; Clear xmm7 value
		;mov rbx, 12BCh

row_loop:						; Main loop

		;xor	rax, rax			; Clear rax value
		;mov al, byte ptr [rsi+rbx]	; Store current pixel in al of rax

		xor r11, r11				; Clear r11 value

		xorps xmm7, xmm7			; For each pixel in the row clear xmm7 which stores local sum


array_y:

		xor r14, r14				; Clear r11 value, it will store offset in array of pixels
		xor rax, rax				; Clear rax value
		mov rax, r15				; Add to current offset bitmap width stored in r15
		push rdx					; Store rdx on stack
		mul r11						; Multiply using column number, result stored in rdx
		mov r14, rax				; Store rax value in r14
		sub r14, r10				; Move to the beginning of the array
		pop rdx						; Get rdx from stack
		add r14, rbx				; Add offset of main row

		xor r12, r12				; Clear r12, it will be used to iterate through all the pixels of a row

array_x:

		xor rax, rax				; Clear rax value

		mov al, byte ptr[rdi + r14] ; Store current pixel value in al

		xorps xmm0, xmm0			; Clear xmm0 value

		cvtsi2ss xmm0, eax			; Convert value from int to float type and store in xmm0
									; CVTSI2SS — Convert Dword Integer to Scalar Single-Precision FP Value

		addss xmm7, xmm0			; Add both vectors

		xor r13, r13				; Clear r13 value
		cvttss2si r13, xmm7;		; Convert value from float to int type and store in rax
									; CVTTSS2SI — Convert with Truncation Scalar Single-Precision FP Value to Dword Integer

array_x_next:
	
		inc r12						; Increment pixels of a row counter
		add r14, 3h					; Move aheah by 3 (R, G, B)
		cmp r12w, dx				; Compare pixels counter with length of row
		jb array_x				; If lower then go to the next pixel
		jb array_y_next			; Else go to the next row

array_y_next:

		inc r11						; Increment columns counter
		cmp r11w, dx				; Compare rows counter with rows count 
		jb array_y				; If lower then go to the next row
		jb analyze					; Else go to local sum analysis

analyze:
		
		xor r12, r12				; Clear r12 value
		mov r12, r13				; Move value from r13 to r12 to perform analysis
		cmp r12b, min				; Compare pixel value with the min possible value
		ja divide					; If higher then go to division procedure
		xor r12, r12				; Else clear r12 value
		mov r12, 0h					; Store oh in r12

divide:

		xor r13, r13				; Clear r13 value
		cvttss2si r13, xmm7;		; Convert float to int and store in r13

		xor rax, rax				; Clear rax value
		mov ax, dx					; Move array height to rax
		xorps xmm1, xmm1			; Clear xmm1 value
		cvtsi2ss xmm1, r13d			; Convert int to float and store sum of pixels in xmm1

		xorps xmm2, xmm2			; Clear xmm2 value
		cvtsi2ss xmm2, eax			; Clear int to float and store value in xmm2
		mulss xmm2, xmm2			; Count pixels count
		divss xmm1, xmm2			; Divide by sum of pixels

		xor rax, rax				; Clear rax value
		cvtss2si rax, xmm1			; Convert float to inv and m ove result to rax

check_max:						; Check if pixel is higher than max value

		cmp al, max					; Compare pixel with max value
		jna check_min				; If at most this value then check min
		mov al, max					; Else assign pixel maximum value

check_min:						; Check if pixel is lower than min value

		cmp al, min					; Compare pixel with min value
		ja save					; If higher then jump to save procedure
		mov al, min					; Else assign pixel minimum value

save:

		mov byte ptr [rsi+rbx], al	; Save pixel value

row_next:

		inc rbx						; Increment offset
		cmp rbx, rcx				; Compare offset rbx with row width rcx
		jb row_loop					; If rbx <= rcx then go to next iteration
		jmp complete						; Else end calculations
		
complete:
									; Pop values from stack to registers
		pop r15
		pop r14
		pop r13
		pop r12
		pop rdi
		pop rsi
		pop rbp
		pop rbx

ret

BlurTransformRowASM endp
END
;-------------------------------------------------------------------------