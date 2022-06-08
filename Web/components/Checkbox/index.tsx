import React from 'react';
import styles from './Checkbox.module.css';

type TextPosition = "left" | "right";

type Props = React.PropsWithChildren<React.InputHTMLAttributes<HTMLInputElement> & {
    textPosition?: TextPosition;
}>;

const Checkbox: React.FC<Props> = ({ children, textPosition, className = "", ...checkboxProps }) => {
    return (
        <label className={styles.container}>
            {textPosition === "left" ? <>{children}&nbsp;</> : null}
            <span className={styles.checkmark} />
            <input {...checkboxProps} type="checkbox" />
            {textPosition === "right" ? <>&nbsp;{children}</> : null}
        </label>        
    );
};

export {Checkbox}