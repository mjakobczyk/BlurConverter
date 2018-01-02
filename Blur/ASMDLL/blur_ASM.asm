.DATA
	max dd 255
	min dd 0
	next dd 3

	_393 dd 0.393
	_769 dd 0.769
	_189 dd 0.189
	
	_349 dd 0.349
	_686 dd 0.686
	_168 dd 0.168

	_272 dd 0.272
	_534 dd 0.534
	_131 dd 0.131

.CODE
BlurTransformRowASM proc
		mov rbx, 0h
loop_start:	
		xorps xmm0, xmm0;
		xorps xmm1, xmm1;
		xorps xmm2, xmm2

		xor	rax, rax
		mov al, byte ptr [rcx+rbx]; 
		cvtsi2ss  xmm0, eax; red color in xmm0
		
		xor	rax, rax
		mov al, byte ptr [rcx+rbx+1];
		cvtsi2ss  xmm1, eax;  green color in xmm1
		
		xor	rax, rax
		mov al, byte ptr [rcx+rbx+2]; 
		cvtsi2ss  xmm2, eax; blue color in xmm2
		
		;---------------------------------------------
		xorps xmm4, xmm4;
		xorps xmm5, xmm5;
		xorps xmm6, xmm6;

		movaps xmm4, xmm0
		movaps xmm5, xmm1
		movaps xmm6, xmm2

		;movaps xmm7, _393

		mulss xmm4, _393
		mulss xmm5, _769
		mulss xmm6, _189
		addps xmm4, xmm5 ; xmm5 is free now
		addps xmm4, xmm6 ; xmm6 is free now
		
		xor	rax, rax
		cvttss2si   rax, xmm4;
		cmp eax, max
		jb short red_negative
		mov eax, max
		red_negative:
		mov byte ptr [rcx+rbx], al ; saving blue color
		
		
		;--------------------------------------
		xorps xmm4, xmm4;
		xorps xmm5, xmm5;
		xorps xmm6, xmm6;

		movaps xmm4, xmm0
		movaps xmm5, xmm1
		movaps xmm6, xmm2

		mulss xmm4, _349
		mulss xmm5, _686
		mulss xmm6, _168
		addps xmm4, xmm5; xmm5 is free now
		addps xmm4, xmm6 ;xmm6 is free now
		
		xor	rax, rax
		cvttss2si   rax, xmm4;
		cmp eax, max
		jb green_negative
		mov eax,max
		green_negative:
		mov byte ptr [rcx+rbx+1], al ; saving green color
				
		;-----------------------------------------------
		xorps xmm4, xmm4;
		xorps xmm5, xmm5;
		xorps xmm6, xmm6;

		movaps xmm4, xmm0
		movaps xmm5, xmm1
		movaps xmm6, xmm2

		mulss xmm4, _272
		mulss xmm5, _534
		mulss xmm6, _131
		addps xmm4, xmm5 ; xmm5 is free now
		addps xmm4, xmm6 ; xmm6 is free now
		
		xor	rax, rax
		cvttss2si   rax, xmm4;
		cmp eax, max
		jb blue_negative
		mov eax, max
		blue_negative: 
		mov byte ptr [rcx+rbx+2], al ; saving blue color

		;------------------------------------------------------
		add rbx, 3h
		dec rdx
		mov rax, rdx
		jnz loop_start
ret

BlurTransformRowASM endp
END
;-------------------------------------------------------------------------
