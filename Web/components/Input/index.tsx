import clsx from 'clsx';
import React, {PropsWithChildren, useRef, useState} from 'react';
import { useClickOutside } from '../../hooks';
import styles from './Input.module.css';

type IconPosition = "left" | "right";

type Props = PropsWithChildren<React.InputHTMLAttributes<HTMLInputElement> & {
    icon?: React.ReactNode;
    iconPosition?: IconPosition;
    label?: React.ReactNode;
}>;

const Input: React.FC<Props> = ({children, icon, iconPosition, label, ...inputProps}) => {
    const ref = useRef<HTMLLabelElement>(null);
    const [focused, setFocused] = useState(false);

    useClickOutside(ref, () => setFocused(false));
    
    return (
        <label
            className={clsx(styles.inputContainer, {
                [styles.leftIcon]: !!icon && iconPosition === "left",
                [styles.rightIcon]: !!icon && iconPosition === "right",
                [styles.active]: focused || !!inputProps.value
            })}
            htmlFor={inputProps.id}
            onClick={() => setFocused(true)}
            ref={ref}
        >
            {iconPosition === "left" ? icon : null}
            <span className={styles.label}>
                {label}
            </span>
            <input {...inputProps} className={styles.input} placeholder={!!label ? "" : inputProps.placeholder}/>
            {iconPosition === "right" ? icon : null}
        </label>
    );
};

export {Input}