import React from 'react';
import styles from './Button.module.css';

type Props = React.PropsWithChildren<React.ButtonHTMLAttributes<HTMLButtonElement> & {
    
}>;

const Button: React.FC<Props> = ({ children, className = "", ...buttonProps}) => {
    return (
        <button {...buttonProps} className={`${styles.button} ${className}`}>
            {children}
        </button>
    );
};

export {Button}