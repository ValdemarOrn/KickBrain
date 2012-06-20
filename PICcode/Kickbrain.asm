
_main:

;Kickbrain.c,14 :: 		void main()
;Kickbrain.c,18 :: 		TRISA = 0b11111111; // analog inputs
	MOVLW       255
	MOVWF       TRISA+0 
;Kickbrain.c,19 :: 		TRISE = 0b11111111; // analog inputs
	MOVLW       255
	MOVWF       TRISE+0 
;Kickbrain.c,20 :: 		TRISB = 0b11111111; // analog inputs
	MOVLW       255
	MOVWF       TRISB+0 
;Kickbrain.c,22 :: 		TRISC = 0b10111111; // inputs, uart TX P6 Output
	MOVLW       191
	MOVWF       TRISC+0 
;Kickbrain.c,23 :: 		TRISD = 0b11111110; // inputs, LED output P0
	MOVLW       254
	MOVWF       TRISD+0 
;Kickbrain.c,25 :: 		PORTB = 0;
	CLRF        PORTB+0 
;Kickbrain.c,26 :: 		PORTA = 0;
	CLRF        PORTA+0 
;Kickbrain.c,27 :: 		PORTC = 0;
	CLRF        PORTC+0 
;Kickbrain.c,28 :: 		PORTD = 0;
	CLRF        PORTD+0 
;Kickbrain.c,31 :: 		INTCON = 0b00000000;
	CLRF        INTCON+0 
;Kickbrain.c,32 :: 		INTCON2.F7 = 1;
	BSF         INTCON2+0, 7 
;Kickbrain.c,33 :: 		INTCON3.F4 = 0;
	BCF         INTCON3+0, 4 
;Kickbrain.c,34 :: 		INTCON3.F3 = 0;
	BCF         INTCON3+0, 3 
;Kickbrain.c,37 :: 		OSCCON = 0b11110000;    // speed of oscillator, 8Mhz
	MOVLW       240
	MOVWF       OSCCON+0 
;Kickbrain.c,38 :: 		OSCTUNE.F6 = 1; 		// PLL enabled, 8*4 = 32Mhz Operation
	BSF         OSCTUNE+0, 6 
;Kickbrain.c,40 :: 		ADCON0.F0 = 1;          // enable AD converter
	BSF         ADCON0+0, 0 
;Kickbrain.c,41 :: 		ADCON1 = 0b00000000;    // AD/digital; all analog
	CLRF        ADCON1+0 
;Kickbrain.c,42 :: 		ADCON2 = 0b00110101;	// 16 TAD, FOsc/16
	MOVLW       53
	MOVWF       ADCON2+0 
;Kickbrain.c,44 :: 		T0CON = 0b00000000;     // timer0 off
	CLRF        T0CON+0 
;Kickbrain.c,48 :: 		UART1_Init(115200);
	MOVLW       16
	MOVWF       SPBRG+0 
	BSF         TXSTA+0, 2, 0
	CALL        _UART1_Init+0, 0
;Kickbrain.c,49 :: 		TXSTA = 0b00100100;
	MOVLW       36
	MOVWF       TXSTA+0 
;Kickbrain.c,52 :: 		ADC_Init();
	CALL        _ADC_Init+0, 0
;Kickbrain.c,54 :: 		for(k = 0; k < CHANNEL_COUNT; k++)
	CLRF        main_k_L0+0 
	CLRF        main_k_L0+1 
L_main0:
	MOVLW       128
	XORWF       main_k_L0+1, 0 
	MOVWF       R0 
	MOVLW       128
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__main36
	MOVLW       11
	SUBWF       main_k_L0+0, 0 
L__main36:
	BTFSC       STATUS+0, 0 
	GOTO        L_main1
;Kickbrain.c,55 :: 		Data[k] = 0;
	MOVLW       _Data+0
	ADDWF       main_k_L0+0, 0 
	MOVWF       FSR1L 
	MOVLW       hi_addr(_Data+0)
	ADDWFC      main_k_L0+1, 0 
	MOVWF       FSR1H 
	CLRF        POSTINC1+0 
;Kickbrain.c,54 :: 		for(k = 0; k < CHANNEL_COUNT; k++)
	INFSNZ      main_k_L0+0, 1 
	INCF        main_k_L0+1, 1 
;Kickbrain.c,55 :: 		Data[k] = 0;
	GOTO        L_main0
L_main1:
;Kickbrain.c,57 :: 		i = -1;
	MOVLW       255
	MOVWF       _i+0 
	MOVLW       255
	MOVWF       _i+1 
;Kickbrain.c,60 :: 		reference = ADC_Get_Sample(REFERENCE_CHANNEL);
	MOVLW       10
	MOVWF       FARG_ADC_Get_Sample_channel+0 
	CALL        _ADC_Get_Sample+0, 0
	MOVF        R0, 0 
	MOVWF       _reference+0 
	MOVF        R1, 0 
	MOVWF       _reference+1 
;Kickbrain.c,63 :: 		PORTD.F0 = 1;
	BSF         PORTD+0, 0 
;Kickbrain.c,64 :: 		Delay_ms(200);
	MOVLW       9
	MOVWF       R11, 0
	MOVLW       30
	MOVWF       R12, 0
	MOVLW       228
	MOVWF       R13, 0
L_main3:
	DECFSZ      R13, 1, 1
	BRA         L_main3
	DECFSZ      R12, 1, 1
	BRA         L_main3
	DECFSZ      R11, 1, 1
	BRA         L_main3
	NOP
;Kickbrain.c,65 :: 		PORTD.F0 = 0;
	BCF         PORTD+0, 0 
;Kickbrain.c,66 :: 		Delay_ms(200);
	MOVLW       9
	MOVWF       R11, 0
	MOVLW       30
	MOVWF       R12, 0
	MOVLW       228
	MOVWF       R13, 0
L_main4:
	DECFSZ      R13, 1, 1
	BRA         L_main4
	DECFSZ      R12, 1, 1
	BRA         L_main4
	DECFSZ      R11, 1, 1
	BRA         L_main4
	NOP
;Kickbrain.c,67 :: 		PORTD.F0 = 1;
	BSF         PORTD+0, 0 
;Kickbrain.c,68 :: 		Delay_ms(200);
	MOVLW       9
	MOVWF       R11, 0
	MOVLW       30
	MOVWF       R12, 0
	MOVLW       228
	MOVWF       R13, 0
L_main5:
	DECFSZ      R13, 1, 1
	BRA         L_main5
	DECFSZ      R12, 1, 1
	BRA         L_main5
	DECFSZ      R11, 1, 1
	BRA         L_main5
	NOP
;Kickbrain.c,69 :: 		PORTD.F0 = 0;
	BCF         PORTD+0, 0 
;Kickbrain.c,70 :: 		Delay_ms(200);
	MOVLW       9
	MOVWF       R11, 0
	MOVLW       30
	MOVWF       R12, 0
	MOVLW       228
	MOVWF       R13, 0
L_main6:
	DECFSZ      R13, 1, 1
	BRA         L_main6
	DECFSZ      R12, 1, 1
	BRA         L_main6
	DECFSZ      R11, 1, 1
	BRA         L_main6
	NOP
;Kickbrain.c,71 :: 		PORTD.F0 = 1;
	BSF         PORTD+0, 0 
;Kickbrain.c,72 :: 		Delay_ms(200);
	MOVLW       9
	MOVWF       R11, 0
	MOVLW       30
	MOVWF       R12, 0
	MOVLW       228
	MOVWF       R13, 0
L_main7:
	DECFSZ      R13, 1, 1
	BRA         L_main7
	DECFSZ      R12, 1, 1
	BRA         L_main7
	DECFSZ      R11, 1, 1
	BRA         L_main7
	NOP
;Kickbrain.c,73 :: 		PORTD.F0 = 0;
	BCF         PORTD+0, 0 
;Kickbrain.c,74 :: 		Delay_ms(200);
	MOVLW       9
	MOVWF       R11, 0
	MOVLW       30
	MOVWF       R12, 0
	MOVLW       228
	MOVWF       R13, 0
L_main8:
	DECFSZ      R13, 1, 1
	BRA         L_main8
	DECFSZ      R12, 1, 1
	BRA         L_main8
	DECFSZ      R11, 1, 1
	BRA         L_main8
	NOP
;Kickbrain.c,75 :: 		PORTD.F0 = 1;
	BSF         PORTD+0, 0 
;Kickbrain.c,76 :: 		Delay_ms(200);
	MOVLW       9
	MOVWF       R11, 0
	MOVLW       30
	MOVWF       R12, 0
	MOVLW       228
	MOVWF       R13, 0
L_main9:
	DECFSZ      R13, 1, 1
	BRA         L_main9
	DECFSZ      R12, 1, 1
	BRA         L_main9
	DECFSZ      R11, 1, 1
	BRA         L_main9
	NOP
;Kickbrain.c,78 :: 		while(1)
L_main10:
;Kickbrain.c,80 :: 		loop();
	CALL        _loop+0, 0
;Kickbrain.c,81 :: 		}
	GOTO        L_main10
;Kickbrain.c,82 :: 		}
	GOTO        $+0
; end of _main

_TrySendSerial:

;Kickbrain.c,84 :: 		void TrySendSerial()
;Kickbrain.c,88 :: 		if( TXSTA.F1 == 0) // check if transmit register is full
	BTFSC       TXSTA+0, 1 
	GOTO        L_TrySendSerial12
;Kickbrain.c,89 :: 		return;
	RETURN      0
L_TrySendSerial12:
;Kickbrain.c,91 :: 		if(i == -1)
	MOVLW       255
	XORWF       _i+1, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__TrySendSerial37
	MOVLW       255
	XORWF       _i+0, 0 
L__TrySendSerial37:
	BTFSS       STATUS+0, 2 
	GOTO        L_TrySendSerial13
;Kickbrain.c,94 :: 		TXREG = 0;
	CLRF        TXREG+0 
;Kickbrain.c,95 :: 		}
	GOTO        L_TrySendSerial14
L_TrySendSerial13:
;Kickbrain.c,98 :: 		output = Data[i];
	MOVLW       _Data+0
	ADDWF       _i+0, 0 
	MOVWF       R0 
	MOVLW       hi_addr(_Data+0)
	ADDWFC      _i+1, 0 
	MOVWF       R1 
	MOVFF       R0, FSR0L
	MOVFF       R1, FSR0H
	MOVF        POSTINC0+0, 0 
	MOVWF       TXREG+0 
;Kickbrain.c,99 :: 		TXREG = output;
;Kickbrain.c,100 :: 		Data[i] = 0;
	MOVFF       R0, FSR1L
	MOVFF       R1, FSR1H
	CLRF        POSTINC1+0 
;Kickbrain.c,101 :: 		}
L_TrySendSerial14:
;Kickbrain.c,103 :: 		i++;
	INFSNZ      _i+0, 1 
	INCF        _i+1, 1 
;Kickbrain.c,104 :: 		if(i >= CHANNEL_COUNT)
	MOVLW       128
	XORWF       _i+1, 0 
	MOVWF       R0 
	MOVLW       128
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__TrySendSerial38
	MOVLW       11
	SUBWF       _i+0, 0 
L__TrySendSerial38:
	BTFSS       STATUS+0, 0 
	GOTO        L_TrySendSerial15
;Kickbrain.c,105 :: 		i = -1;
	MOVLW       255
	MOVWF       _i+0 
	MOVLW       255
	MOVWF       _i+1 
L_TrySendSerial15:
;Kickbrain.c,106 :: 		}
	RETURN      0
; end of _TrySendSerial

_loop:

;Kickbrain.c,109 :: 		void loop()
;Kickbrain.c,119 :: 		reference = (reference * 7 + ADC_Get_Sample(REFERENCE_CHANNEL)) >> 3; // (7*ref + 1*read) / 8
	MOVF        _reference+0, 0 
	MOVWF       R0 
	MOVF        _reference+1, 0 
	MOVWF       R1 
	MOVLW       7
	MOVWF       R4 
	MOVLW       0
	MOVWF       R5 
	CALL        _Mul_16x16_U+0, 0
	MOVF        R0, 0 
	MOVWF       FLOC__loop+0 
	MOVF        R1, 0 
	MOVWF       FLOC__loop+1 
	MOVLW       10
	MOVWF       FARG_ADC_Get_Sample_channel+0 
	CALL        _ADC_Get_Sample+0, 0
	MOVF        R0, 0 
	ADDWF       FLOC__loop+0, 0 
	MOVWF       _reference+0 
	MOVF        R1, 0 
	ADDWFC      FLOC__loop+1, 0 
	MOVWF       _reference+1 
	MOVLW       3
	MOVWF       R0 
	MOVF        R0, 0 
L__loop39:
	BZ          L__loop40
	RRCF        _reference+1, 1 
	RRCF        _reference+0, 1 
	BCF         _reference+1, 7 
	ADDLW       255
	GOTO        L__loop39
L__loop40:
;Kickbrain.c,121 :: 		for(k=0; k < CHANNEL_COUNT; k++)
	CLRF        loop_k_L0+0 
	CLRF        loop_k_L0+1 
L_loop16:
	MOVLW       128
	XORWF       loop_k_L0+1, 0 
	MOVWF       R0 
	MOVLW       128
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__loop41
	MOVLW       11
	SUBWF       loop_k_L0+0, 0 
L__loop41:
	BTFSC       STATUS+0, 0 
	GOTO        L_loop17
;Kickbrain.c,123 :: 		if(k == 9 && HIHAT_ENABLED) // read the hihat value, if this is a hihat model
	MOVLW       0
	XORWF       loop_k_L0+1, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__loop42
	MOVLW       9
	XORWF       loop_k_L0+0, 0 
L__loop42:
	BTFSS       STATUS+0, 2 
	GOTO        L_loop21
L__loop35:
;Kickbrain.c,125 :: 		value = ADC_Get_Sample(k);
	MOVF        loop_k_L0+0, 0 
	MOVWF       FARG_ADC_Get_Sample_channel+0 
	CALL        _ADC_Get_Sample+0, 0
	MOVF        R0, 0 
	MOVWF       loop_value_L0+0 
	MOVF        R1, 0 
	MOVWF       loop_value_L0+1 
;Kickbrain.c,126 :: 		value = value >> 2;
	MOVF        R0, 0 
	MOVWF       R2 
	MOVF        R1, 0 
	MOVWF       R3 
	RRCF        R3, 1 
	RRCF        R2, 1 
	BCF         R3, 7 
	BTFSC       R3, 6 
	BSF         R3, 7 
	RRCF        R3, 1 
	RRCF        R2, 1 
	BCF         R3, 7 
	BTFSC       R3, 6 
	BSF         R3, 7 
	MOVF        R2, 0 
	MOVWF       loop_value_L0+0 
	MOVF        R3, 0 
	MOVWF       loop_value_L0+1 
;Kickbrain.c,129 :: 		if (value <= 0)
	MOVLW       128
	MOVWF       R0 
	MOVLW       128
	XORWF       R3, 0 
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__loop43
	MOVF        R2, 0 
	SUBLW       0
L__loop43:
	BTFSS       STATUS+0, 0 
	GOTO        L_loop22
;Kickbrain.c,130 :: 		value = 1;
	MOVLW       1
	MOVWF       loop_value_L0+0 
	MOVLW       0
	MOVWF       loop_value_L0+1 
L_loop22:
;Kickbrain.c,132 :: 		if(value > Data[k]) // preserve peaks
	MOVLW       _Data+0
	ADDWF       loop_k_L0+0, 0 
	MOVWF       FSR2L 
	MOVLW       hi_addr(_Data+0)
	ADDWFC      loop_k_L0+1, 0 
	MOVWF       FSR2H 
	MOVF        POSTINC2+0, 0 
	MOVWF       R1 
	MOVLW       128
	MOVWF       R0 
	MOVLW       128
	XORWF       loop_value_L0+1, 0 
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__loop44
	MOVF        loop_value_L0+0, 0 
	SUBWF       R1, 0 
L__loop44:
	BTFSC       STATUS+0, 0 
	GOTO        L_loop23
;Kickbrain.c,133 :: 		Data[k] = (unsigned char)value;
	MOVLW       _Data+0
	ADDWF       loop_k_L0+0, 0 
	MOVWF       FSR1L 
	MOVLW       hi_addr(_Data+0)
	ADDWFC      loop_k_L0+1, 0 
	MOVWF       FSR1H 
	MOVF        loop_value_L0+0, 0 
	MOVWF       POSTINC1+0 
L_loop23:
;Kickbrain.c,134 :: 		}
	GOTO        L_loop24
L_loop21:
;Kickbrain.c,135 :: 		else if (k == 10) // AD channels are 0-9, channel 10 is for digital switches
	MOVLW       0
	XORWF       loop_k_L0+1, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__loop45
	MOVLW       10
	XORWF       loop_k_L0+0, 0 
L__loop45:
	BTFSS       STATUS+0, 2 
	GOTO        L_loop25
;Kickbrain.c,137 :: 		value = 1 | (PORTC.F0 << 4) | (PORTC.F1 << 5);
	CLRF        R3 
	BTFSC       PORTC+0, 0 
	INCF        R3, 1 
	MOVLW       4
	MOVWF       R2 
	MOVF        R3, 0 
	MOVWF       R0 
	MOVLW       0
	MOVWF       R1 
	MOVF        R2, 0 
L__loop46:
	BZ          L__loop47
	RLCF        R0, 1 
	BCF         R0, 0 
	RLCF        R1, 1 
	ADDLW       255
	GOTO        L__loop46
L__loop47:
	MOVLW       1
	IORWF       R0, 0 
	MOVWF       R4 
	MOVF        R1, 0 
	MOVWF       R5 
	MOVLW       0
	IORWF       R5, 1 
	CLRF        R3 
	BTFSC       PORTC+0, 1 
	INCF        R3, 1 
	MOVLW       5
	MOVWF       R2 
	MOVF        R3, 0 
	MOVWF       R0 
	MOVLW       0
	MOVWF       R1 
	MOVF        R2, 0 
L__loop48:
	BZ          L__loop49
	RLCF        R0, 1 
	BCF         R0, 0 
	RLCF        R1, 1 
	ADDLW       255
	GOTO        L__loop48
L__loop49:
	MOVF        R4, 0 
	IORWF       R0, 1 
	MOVF        R5, 0 
	IORWF       R1, 1 
	MOVF        R0, 0 
	MOVWF       loop_value_L0+0 
	MOVF        R1, 0 
	MOVWF       loop_value_L0+1 
;Kickbrain.c,139 :: 		Data[k] = (unsigned char)value;
	MOVLW       _Data+0
	ADDWF       loop_k_L0+0, 0 
	MOVWF       FSR1L 
	MOVLW       hi_addr(_Data+0)
	ADDWFC      loop_k_L0+1, 0 
	MOVWF       FSR1H 
	MOVF        R0, 0 
	MOVWF       POSTINC1+0 
;Kickbrain.c,140 :: 		}
	GOTO        L_loop26
L_loop25:
;Kickbrain.c,143 :: 		value = ADC_Get_Sample(k);
	MOVF        loop_k_L0+0, 0 
	MOVWF       FARG_ADC_Get_Sample_channel+0 
	CALL        _ADC_Get_Sample+0, 0
	MOVF        R0, 0 
	MOVWF       loop_value_L0+0 
	MOVF        R1, 0 
	MOVWF       loop_value_L0+1 
;Kickbrain.c,144 :: 		value = (value-reference);
	MOVF        _reference+0, 0 
	SUBWF       R0, 0 
	MOVWF       R2 
	MOVF        _reference+1, 0 
	SUBWFB      R1, 0 
	MOVWF       R3 
	MOVF        R2, 0 
	MOVWF       loop_value_L0+0 
	MOVF        R3, 0 
	MOVWF       loop_value_L0+1 
;Kickbrain.c,146 :: 		if(value < 0)
	MOVLW       128
	XORWF       R3, 0 
	MOVWF       R0 
	MOVLW       128
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__loop50
	MOVLW       0
	SUBWF       R2, 0 
L__loop50:
	BTFSC       STATUS+0, 0 
	GOTO        L_loop27
;Kickbrain.c,147 :: 		value = 0;
	CLRF        loop_value_L0+0 
	CLRF        loop_value_L0+1 
L_loop27:
;Kickbrain.c,149 :: 		value = value >> 1; // limit between 0..255
	MOVF        loop_value_L0+0, 0 
	MOVWF       R1 
	MOVF        loop_value_L0+1, 0 
	MOVWF       R2 
	RRCF        R2, 1 
	RRCF        R1, 1 
	BCF         R2, 7 
	BTFSC       R2, 6 
	BSF         R2, 7 
	MOVF        R1, 0 
	MOVWF       loop_value_L0+0 
	MOVF        R2, 0 
	MOVWF       loop_value_L0+1 
;Kickbrain.c,151 :: 		if(value > 255)  // because reference is not exactly 512,
	MOVLW       128
	MOVWF       R0 
	MOVLW       128
	XORWF       R2, 0 
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__loop51
	MOVF        R1, 0 
	SUBLW       255
L__loop51:
	BTFSC       STATUS+0, 0 
	GOTO        L_loop28
;Kickbrain.c,152 :: 		value = 255; // there can be a slight offset. Make sure numbers don't overflow
	MOVLW       255
	MOVWF       loop_value_L0+0 
	MOVLW       0
	MOVWF       loop_value_L0+1 
L_loop28:
;Kickbrain.c,155 :: 		if (value <= 0)
	MOVLW       128
	MOVWF       R0 
	MOVLW       128
	XORWF       loop_value_L0+1, 0 
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__loop52
	MOVF        loop_value_L0+0, 0 
	SUBLW       0
L__loop52:
	BTFSS       STATUS+0, 0 
	GOTO        L_loop29
;Kickbrain.c,156 :: 		value = 1;
	MOVLW       1
	MOVWF       loop_value_L0+0 
	MOVLW       0
	MOVWF       loop_value_L0+1 
L_loop29:
;Kickbrain.c,158 :: 		if(value > Data[k]) // preserve peaks
	MOVLW       _Data+0
	ADDWF       loop_k_L0+0, 0 
	MOVWF       FSR2L 
	MOVLW       hi_addr(_Data+0)
	ADDWFC      loop_k_L0+1, 0 
	MOVWF       FSR2H 
	MOVF        POSTINC2+0, 0 
	MOVWF       R1 
	MOVLW       128
	MOVWF       R0 
	MOVLW       128
	XORWF       loop_value_L0+1, 0 
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__loop53
	MOVF        loop_value_L0+0, 0 
	SUBWF       R1, 0 
L__loop53:
	BTFSC       STATUS+0, 0 
	GOTO        L_loop30
;Kickbrain.c,159 :: 		Data[k] = (unsigned char)value;
	MOVLW       _Data+0
	ADDWF       loop_k_L0+0, 0 
	MOVWF       FSR1L 
	MOVLW       hi_addr(_Data+0)
	ADDWFC      loop_k_L0+1, 0 
	MOVWF       FSR1H 
	MOVF        loop_value_L0+0, 0 
	MOVWF       POSTINC1+0 
L_loop30:
;Kickbrain.c,160 :: 		}
L_loop26:
L_loop24:
;Kickbrain.c,162 :: 		TrySendSerial();
	CALL        _TrySendSerial+0, 0
;Kickbrain.c,121 :: 		for(k=0; k < CHANNEL_COUNT; k++)
	INFSNZ      loop_k_L0+0, 1 
	INCF        loop_k_L0+1, 1 
;Kickbrain.c,163 :: 		}
	GOTO        L_loop16
L_loop17:
;Kickbrain.c,166 :: 		}
	RETURN      0
; end of _loop

_serialEvent:

;Kickbrain.c,169 :: 		void serialEvent() {
;Kickbrain.c,170 :: 		while (UART1_Data_Ready())
L_serialEvent31:
	CALL        _UART1_Data_Ready+0, 0
	MOVF        R0, 1 
	BTFSC       STATUS+0, 2 
	GOTO        L_serialEvent32
;Kickbrain.c,174 :: 		input = UART1_Read();
	CALL        _UART1_Read+0, 0
	MOVF        R0, 0 
	MOVWF       serialEvent_input_L1+0 
	MOVLW       0
	MOVWF       serialEvent_input_L1+1 
;Kickbrain.c,176 :: 		if(input >= 128)
	MOVLW       128
	XORWF       serialEvent_input_L1+1, 0 
	MOVWF       R0 
	MOVLW       128
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__serialEvent54
	MOVLW       128
	SUBWF       serialEvent_input_L1+0, 0 
L__serialEvent54:
	BTFSS       STATUS+0, 0 
	GOTO        L_serialEvent33
;Kickbrain.c,178 :: 		input = input - 128;
	MOVLW       128
	SUBWF       serialEvent_input_L1+0, 1 
	MOVLW       0
	SUBWFB      serialEvent_input_L1+1, 1 
;Kickbrain.c,179 :: 		}
	GOTO        L_serialEvent34
L_serialEvent33:
;Kickbrain.c,184 :: 		}
L_serialEvent34:
;Kickbrain.c,185 :: 		}
	GOTO        L_serialEvent31
L_serialEvent32:
;Kickbrain.c,186 :: 		}
	RETURN      0
; end of _serialEvent
