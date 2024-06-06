import React, { InputHTMLAttributes, useCallback } from 'react';

type Props = Omit<InputHTMLAttributes<HTMLInputElement>, "onChange" | "value"> & {
    value: string;
    onValueChange: (value: string) => void;
};

export const Input = React.memo(function Input({ onValueChange, ...inputProps }: Props) {
    const onChange = useCallback((event: React.ChangeEvent<HTMLInputElement>) => {
        onValueChange(event.target.value);
    }, [onValueChange])
    
    return (
        <input onChange={onChange} {...inputProps} />
    );
})