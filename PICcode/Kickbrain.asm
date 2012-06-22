
_ADCsample:

;Kickbrain.c,15 :: 		unsigned ADCsample(unsigned short channel)
;Kickbrain.c,19 :: 		channel = (channel & 0x0F) << 2;
	MOVLW       15
	ANDWF       FARG_ADCsample_channel+0, 0 
	MOVWF       R2 
	MOVF        R2, 0 
	MOVWF       R0 
	RLCF        R0, 1 
	BCF         R0, 0 
	RLCF        R0, 1 
	BCF         R0, 0 
	MOVF        R0, 0 
	MOVWF       FARG_ADCsample_channel+0 
;Kickbrain.c,20 :: 		ADCON0 = ADCON0 & 0b11000011;
	MOVLW       195
	ANDWF       ADCON0+0, 1 
;Kickbrain.c,21 :: 		ADCON0 = ADCON0 | channel;
	MOVF        R0, 0 
	IORWF       ADCON0+0, 1 
;Kickbrain.c,22 :: 		ADCON0.F1 = 1;
	BSF         ADCON0+0, 1 
;Kickbrain.c,25 :: 		while(ADCON0.F1 == 1)
L_ADCsample0:
	BTFSS       ADCON0+0, 1 
	GOTO        L_ADCsample1
;Kickbrain.c,26 :: 		{TrySendSerial();}
	CALL        _TrySendSerial+0, 0
	GOTO        L_ADCsample0
L_ADCsample1:
;Kickbrain.c,28 :: 		output = (ADRESH & 0b00000011);
	MOVLW       3
	ANDWF       ADRESH+0, 0 
	MOVWF       ADCsample_output_L0+0 
	CLRF        ADCsample_output_L0+1 
	MOVLW       0
	ANDWF       ADCsample_output_L0+1, 1 
	MOVLW       0
	MOVWF       ADCsample_output_L0+1 
;Kickbrain.c,29 :: 		output = output * 256;
	MOVF        ADCsample_output_L0+0, 0 
	MOVWF       R1 
	CLRF        R0 
	MOVF        R0, 0 
	MOVWF       ADCsample_output_L0+0 
	MOVF        R1, 0 
	MOVWF       ADCsample_output_L0+1 
;Kickbrain.c,30 :: 		output = output + ADRESL;
	MOVF        ADRESL+0, 0 
	ADDWF       R0, 1 
	MOVLW       0
	ADDWFC      R1, 1 
	MOVF        R0, 0 
	MOVWF       ADCsample_output_L0+0 
	MOVF        R1, 0 
	MOVWF       ADCsample_output_L0+1 
;Kickbrain.c,31 :: 		return output;
;Kickbrain.c,32 :: 		}
	RETURN      0
; end of _ADCsample

_main:

;Kickbrain.c,34 :: 		void main()
;Kickbrain.c,38 :: 		TRISA = 0b11111111; // analog inputs
	MOVLW       255
	MOVWF       TRISA+0 
;Kickbrain.c,39 :: 		TRISE = 0b11111111; // analog inputs
	MOVLW       255
	MOVWF       TRISE+0 
;Kickbrain.c,40 :: 		TRISB = 0b11111111; // analog inputs
	MOVLW       255
	MOVWF       TRISB+0 
;Kickbrain.c,42 :: 		TRISC = 0b10111111; // inputs, uart TX P6 Output
	MOVLW       191
	MOVWF       TRISC+0 
;Kickbrain.c,43 :: 		TRISD = 0b11111110; // inputs, LED output P0
	MOVLW       254
	MOVWF       TRISD+0 
;Kickbrain.c,45 :: 		PORTB = 0;
	CLRF        PORTB+0 
;Kickbrain.c,46 :: 		PORTA = 0;
	CLRF        PORTA+0 
;Kickbrain.c,47 :: 		PORTC = 0;
	CLRF        PORTC+0 
;Kickbrain.c,48 :: 		PORTD = 0;
	CLRF        PORTD+0 
;Kickbrain.c,51 :: 		INTCON = 0b00000000;
	CLRF        INTCON+0 
;Kickbrain.c,52 :: 		INTCON2.F7 = 1;
	BSF         INTCON2+0, 7 
;Kickbrain.c,53 :: 		INTCON3.F4 = 0;
	BCF         INTCON3+0, 4 
;Kickbrain.c,54 :: 		INTCON3.F3 = 0;
	BCF         INTCON3+0, 3 
;Kickbrain.c,57 :: 		OSCCON = 0b11110000;    // speed of oscillator, 8Mhz
	MOVLW       240
	MOVWF       OSCCON+0 
;Kickbrain.c,58 :: 		OSCTUNE.F6 = 1; 		// PLL enabled, 8*4 = 32Mhz Operation
	BSF         OSCTUNE+0, 6 
;Kickbrain.c,60 :: 		ADCON0.F0 = 1;          // enable AD converter
	BSF         ADCON0+0, 0 
;Kickbrain.c,61 :: 		ADCON1 = 0b00000000;    // AD/digital; all analog
	CLRF        ADCON1+0 
;Kickbrain.c,62 :: 		ADCON2 = 0b10110101;	// 16 TAD, FOsc/16
	MOVLW       181
	MOVWF       ADCON2+0 
;Kickbrain.c,64 :: 		T0CON = 0b00000000;     // timer0 off
	CLRF        T0CON+0 
;Kickbrain.c,68 :: 		UART1_Init(115200);
	MOVLW       16
	MOVWF       SPBRG+0 
	BSF         TXSTA+0, 2, 0
	CALL        _UART1_Init+0, 0
;Kickbrain.c,69 :: 		TXSTA = 0b00100100;
	MOVLW       36
	MOVWF       TXSTA+0 
;Kickbrain.c,74 :: 		for(k = 0; k < CHANNEL_COUNT; k++)
	CLRF        main_k_L0+0 
	CLRF        main_k_L0+1 
L_main2:
	MOVLW       128
	XORWF       main_k_L0+1, 0 
	MOVWF       R0 
	MOVLW       128
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__main38
	MOVLW       11
	SUBWF       main_k_L0+0, 0 
L__main38:
	BTFSC       STATUS+0, 0 
	GOTO        L_main3
;Kickbrain.c,75 :: 		Data[k] = 0;
	MOVLW       _Data+0
	ADDWF       main_k_L0+0, 0 
	MOVWF       FSR1L 
	MOVLW       hi_addr(_Data+0)
	ADDWFC      main_k_L0+1, 0 
	MOVWF       FSR1H 
	CLRF        POSTINC1+0 
;Kickbrain.c,74 :: 		for(k = 0; k < CHANNEL_COUNT; k++)
	INFSNZ      main_k_L0+0, 1 
	INCF        main_k_L0+1, 1 
;Kickbrain.c,75 :: 		Data[k] = 0;
	GOTO        L_main2
L_main3:
;Kickbrain.c,77 :: 		i = -1;
	MOVLW       255
	MOVWF       _i+0 
	MOVLW       255
	MOVWF       _i+1 
;Kickbrain.c,80 :: 		reference = ADCsample(REFERENCE_CHANNEL);
	MOVLW       10
	MOVWF       FARG_ADCsample_channel+0 
	CALL        _ADCsample+0, 0
	MOVF        R0, 0 
	MOVWF       _reference+0 
	MOVF        R1, 0 
	MOVWF       _reference+1 
;Kickbrain.c,83 :: 		PORTD.F0 = 1;
	BSF         PORTD+0, 0 
;Kickbrain.c,84 :: 		Delay_ms(200);
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
;Kickbrain.c,85 :: 		PORTD.F0 = 0;
	BCF         PORTD+0, 0 
;Kickbrain.c,86 :: 		Delay_ms(200);
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
;Kickbrain.c,87 :: 		PORTD.F0 = 1;
	BSF         PORTD+0, 0 
;Kickbrain.c,88 :: 		Delay_ms(200);
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
;Kickbrain.c,89 :: 		PORTD.F0 = 0;
	BCF         PORTD+0, 0 
;Kickbrain.c,90 :: 		Delay_ms(200);
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
;Kickbrain.c,91 :: 		PORTD.F0 = 1;
	BSF         PORTD+0, 0 
;Kickbrain.c,92 :: 		Delay_ms(200);
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
;Kickbrain.c,93 :: 		PORTD.F0 = 0;
	BCF         PORTD+0, 0 
;Kickbrain.c,94 :: 		Delay_ms(200);
	MOVLW       9
	MOVWF       R11, 0
	MOVLW       30
	MOVWF       R12, 0
	MOVLW       228
	MOVWF       R13, 0
L_main10:
	DECFSZ      R13, 1, 1
	BRA         L_main10
	DECFSZ      R12, 1, 1
	BRA         L_main10
	DECFSZ      R11, 1, 1
	BRA         L_main10
	NOP
;Kickbrain.c,95 :: 		PORTD.F0 = 1;
	BSF         PORTD+0, 0 
;Kickbrain.c,96 :: 		Delay_ms(200);
	MOVLW       9
	MOVWF       R11, 0
	MOVLW       30
	MOVWF       R12, 0
	MOVLW       228
	MOVWF       R13, 0
L_main11:
	DECFSZ      R13, 1, 1
	BRA         L_main11
	DECFSZ      R12, 1, 1
	BRA         L_main11
	DECFSZ      R11, 1, 1
	BRA         L_main11
	NOP
;Kickbrain.c,98 :: 		while(1)
L_main12:
;Kickbrain.c,100 :: 		loop();
	CALL        _loop+0, 0
;Kickbrain.c,101 :: 		}
	GOTO        L_main12
;Kickbrain.c,102 :: 		}
	GOTO        $+0
; end of _main

_TrySendSerial:

;Kickbrain.c,104 :: 		void TrySendSerial()
;Kickbrain.c,108 :: 		if( TXSTA.F1 == 0) // check if transmit register is full
	BTFSC       TXSTA+0, 1 
	GOTO        L_TrySendSerial14
;Kickbrain.c,109 :: 		return;
	RETURN      0
L_TrySendSerial14:
;Kickbrain.c,111 :: 		if(i == -1)
	MOVLW       255
	XORWF       _i+1, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__TrySendSerial39
	MOVLW       255
	XORWF       _i+0, 0 
L__TrySendSerial39:
	BTFSS       STATUS+0, 2 
	GOTO        L_TrySendSerial15
;Kickbrain.c,114 :: 		TXREG = 0;
	CLRF        TXREG+0 
;Kickbrain.c,115 :: 		}
	GOTO        L_TrySendSerial16
L_TrySendSerial15:
;Kickbrain.c,118 :: 		output = Data[i];
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
;Kickbrain.c,119 :: 		TXREG = output;
;Kickbrain.c,120 :: 		Data[i] = 0;
	MOVFF       R0, FSR1L
	MOVFF       R1, FSR1H
	CLRF        POSTINC1+0 
;Kickbrain.c,121 :: 		}
L_TrySendSerial16:
;Kickbrain.c,123 :: 		i++;
	INFSNZ      _i+0, 1 
	INCF        _i+1, 1 
;Kickbrain.c,124 :: 		if(i >= CHANNEL_COUNT)
	MOVLW       128
	XORWF       _i+1, 0 
	MOVWF       R0 
	MOVLW       128
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__TrySendSerial40
	MOVLW       11
	SUBWF       _i+0, 0 
L__TrySendSerial40:
	BTFSS       STATUS+0, 0 
	GOTO        L_TrySendSerial17
;Kickbrain.c,125 :: 		i = -1;
	MOVLW       255
	MOVWF       _i+0 
	MOVLW       255
	MOVWF       _i+1 
L_TrySendSerial17:
;Kickbrain.c,126 :: 		}
	RETURN      0
; end of _TrySendSerial

_loop:

;Kickbrain.c,129 :: 		void loop()
;Kickbrain.c,139 :: 		reference = (reference * 7 + ADCsample(REFERENCE_CHANNEL)) >> 3; // (7*ref + 1*read) / 8
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
	MOVWF       FARG_ADCsample_channel+0 
	CALL        _ADCsample+0, 0
	MOVF        R0, 0 
	ADDWF       FLOC__loop+0, 0 
	MOVWF       _reference+0 
	MOVF        R1, 0 
	ADDWFC      FLOC__loop+1, 0 
	MOVWF       _reference+1 
	MOVLW       3
	MOVWF       R0 
	MOVF        R0, 0 
L__loop41:
	BZ          L__loop42
	RRCF        _reference+1, 1 
	RRCF        _reference+0, 1 
	BCF         _reference+1, 7 
	ADDLW       255
	GOTO        L__loop41
L__loop42:
;Kickbrain.c,141 :: 		for(k=0; k < CHANNEL_COUNT; k++)
	CLRF        loop_k_L0+0 
	CLRF        loop_k_L0+1 
L_loop18:
	MOVLW       128
	XORWF       loop_k_L0+1, 0 
	MOVWF       R0 
	MOVLW       128
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__loop43
	MOVLW       11
	SUBWF       loop_k_L0+0, 0 
L__loop43:
	BTFSC       STATUS+0, 0 
	GOTO        L_loop19
;Kickbrain.c,143 :: 		if(k == 9 && HIHAT_ENABLED) // read the hihat value, if this is a hihat model
	MOVLW       0
	XORWF       loop_k_L0+1, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__loop44
	MOVLW       9
	XORWF       loop_k_L0+0, 0 
L__loop44:
	BTFSS       STATUS+0, 2 
	GOTO        L_loop23
L__loop37:
;Kickbrain.c,145 :: 		value = ADCsample(k);
	MOVF        loop_k_L0+0, 0 
	MOVWF       FARG_ADCsample_channel+0 
	CALL        _ADCsample+0, 0
	MOVF        R0, 0 
	MOVWF       loop_value_L0+0 
	MOVF        R1, 0 
	MOVWF       loop_value_L0+1 
;Kickbrain.c,146 :: 		value = value >> 2;
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
;Kickbrain.c,149 :: 		if (value <= 0)
	MOVLW       128
	MOVWF       R0 
	MOVLW       128
	XORWF       R3, 0 
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__loop45
	MOVF        R2, 0 
	SUBLW       0
L__loop45:
	BTFSS       STATUS+0, 0 
	GOTO        L_loop24
;Kickbrain.c,150 :: 		value = 1;
	MOVLW       1
	MOVWF       loop_value_L0+0 
	MOVLW       0
	MOVWF       loop_value_L0+1 
L_loop24:
;Kickbrain.c,152 :: 		if(value > Data[k]) // preserve peaks
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
	GOTO        L__loop46
	MOVF        loop_value_L0+0, 0 
	SUBWF       R1, 0 
L__loop46:
	BTFSC       STATUS+0, 0 
	GOTO        L_loop25
;Kickbrain.c,153 :: 		Data[k] = (unsigned char)value;
	MOVLW       _Data+0
	ADDWF       loop_k_L0+0, 0 
	MOVWF       FSR1L 
	MOVLW       hi_addr(_Data+0)
	ADDWFC      loop_k_L0+1, 0 
	MOVWF       FSR1H 
	MOVF        loop_value_L0+0, 0 
	MOVWF       POSTINC1+0 
L_loop25:
;Kickbrain.c,154 :: 		}
	GOTO        L_loop26
L_loop23:
;Kickbrain.c,155 :: 		else if (k == 10) // AD channels are 0-9, channel 10 is for digital switches
	MOVLW       0
	XORWF       loop_k_L0+1, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__loop47
	MOVLW       10
	XORWF       loop_k_L0+0, 0 
L__loop47:
	BTFSS       STATUS+0, 2 
	GOTO        L_loop27
;Kickbrain.c,157 :: 		value = 1 | (PORTC.F0 << 4) | (PORTC.F1 << 5);
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
L__loop48:
	BZ          L__loop49
	RLCF        R0, 1 
	BCF         R0, 0 
	RLCF        R1, 1 
	ADDLW       255
	GOTO        L__loop48
L__loop49:
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
L__loop50:
	BZ          L__loop51
	RLCF        R0, 1 
	BCF         R0, 0 
	RLCF        R1, 1 
	ADDLW       255
	GOTO        L__loop50
L__loop51:
	MOVF        R4, 0 
	IORWF       R0, 1 
	MOVF        R5, 0 
	IORWF       R1, 1 
	MOVF        R0, 0 
	MOVWF       loop_value_L0+0 
	MOVF        R1, 0 
	MOVWF       loop_value_L0+1 
;Kickbrain.c,159 :: 		Data[k] = (unsigned char)value;
	MOVLW       _Data+0
	ADDWF       loop_k_L0+0, 0 
	MOVWF       FSR1L 
	MOVLW       hi_addr(_Data+0)
	ADDWFC      loop_k_L0+1, 0 
	MOVWF       FSR1H 
	MOVF        R0, 0 
	MOVWF       POSTINC1+0 
;Kickbrain.c,160 :: 		}
	GOTO        L_loop28
L_loop27:
;Kickbrain.c,163 :: 		value = ADCsample(k);
	MOVF        loop_k_L0+0, 0 
	MOVWF       FARG_ADCsample_channel+0 
	CALL        _ADCsample+0, 0
	MOVF        R0, 0 
	MOVWF       loop_value_L0+0 
	MOVF        R1, 0 
	MOVWF       loop_value_L0+1 
;Kickbrain.c,164 :: 		value = (value-reference);
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
;Kickbrain.c,166 :: 		if(value < 0)
	MOVLW       128
	XORWF       R3, 0 
	MOVWF       R0 
	MOVLW       128
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__loop52
	MOVLW       0
	SUBWF       R2, 0 
L__loop52:
	BTFSC       STATUS+0, 0 
	GOTO        L_loop29
;Kickbrain.c,167 :: 		value = 0;
	CLRF        loop_value_L0+0 
	CLRF        loop_value_L0+1 
L_loop29:
;Kickbrain.c,171 :: 		if(value > 255)  // because reference is not exactly 512,
	MOVLW       128
	MOVWF       R0 
	MOVLW       128
	XORWF       loop_value_L0+1, 0 
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__loop53
	MOVF        loop_value_L0+0, 0 
	SUBLW       255
L__loop53:
	BTFSC       STATUS+0, 0 
	GOTO        L_loop30
;Kickbrain.c,172 :: 		value = 255; // there can be a slight offset. Make sure numbers don't overflow
	MOVLW       255
	MOVWF       loop_value_L0+0 
	MOVLW       0
	MOVWF       loop_value_L0+1 
L_loop30:
;Kickbrain.c,175 :: 		if (value <= 0)
	MOVLW       128
	MOVWF       R0 
	MOVLW       128
	XORWF       loop_value_L0+1, 0 
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__loop54
	MOVF        loop_value_L0+0, 0 
	SUBLW       0
L__loop54:
	BTFSS       STATUS+0, 0 
	GOTO        L_loop31
;Kickbrain.c,176 :: 		value = 1;
	MOVLW       1
	MOVWF       loop_value_L0+0 
	MOVLW       0
	MOVWF       loop_value_L0+1 
L_loop31:
;Kickbrain.c,178 :: 		if(value > Data[k]) // preserve peaks
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
	GOTO        L__loop55
	MOVF        loop_value_L0+0, 0 
	SUBWF       R1, 0 
L__loop55:
	BTFSC       STATUS+0, 0 
	GOTO        L_loop32
;Kickbrain.c,179 :: 		Data[k] = (unsigned char)value;
	MOVLW       _Data+0
	ADDWF       loop_k_L0+0, 0 
	MOVWF       FSR1L 
	MOVLW       hi_addr(_Data+0)
	ADDWFC      loop_k_L0+1, 0 
	MOVWF       FSR1H 
	MOVF        loop_value_L0+0, 0 
	MOVWF       POSTINC1+0 
L_loop32:
;Kickbrain.c,180 :: 		}
L_loop28:
L_loop26:
;Kickbrain.c,182 :: 		TrySendSerial();
	CALL        _TrySendSerial+0, 0
;Kickbrain.c,141 :: 		for(k=0; k < CHANNEL_COUNT; k++)
	INFSNZ      loop_k_L0+0, 1 
	INCF        loop_k_L0+1, 1 
;Kickbrain.c,183 :: 		}
	GOTO        L_loop18
L_loop19:
;Kickbrain.c,186 :: 		}
	RETURN      0
; end of _loop

_serialEvent:

;Kickbrain.c,189 :: 		void serialEvent() {
;Kickbrain.c,190 :: 		while (UART1_Data_Ready())
L_serialEvent33:
	CALL        _UART1_Data_Ready+0, 0
	MOVF        R0, 1 
	BTFSC       STATUS+0, 2 
	GOTO        L_serialEvent34
;Kickbrain.c,194 :: 		input = UART1_Read();
	CALL        _UART1_Read+0, 0
	MOVF        R0, 0 
	MOVWF       serialEvent_input_L1+0 
	MOVLW       0
	MOVWF       serialEvent_input_L1+1 
;Kickbrain.c,196 :: 		if(input >= 128)
	MOVLW       128
	XORWF       serialEvent_input_L1+1, 0 
	MOVWF       R0 
	MOVLW       128
	SUBWF       R0, 0 
	BTFSS       STATUS+0, 2 
	GOTO        L__serialEvent56
	MOVLW       128
	SUBWF       serialEvent_input_L1+0, 0 
L__serialEvent56:
	BTFSS       STATUS+0, 0 
	GOTO        L_serialEvent35
;Kickbrain.c,198 :: 		input = input - 128;
	MOVLW       128
	SUBWF       serialEvent_input_L1+0, 1 
	MOVLW       0
	SUBWFB      serialEvent_input_L1+1, 1 
;Kickbrain.c,199 :: 		}
	GOTO        L_serialEvent36
L_serialEvent35:
;Kickbrain.c,204 :: 		}
L_serialEvent36:
;Kickbrain.c,205 :: 		}
	GOTO        L_serialEvent33
L_serialEvent34:
;Kickbrain.c,206 :: 		}
	RETURN      0
; end of _serialEvent
