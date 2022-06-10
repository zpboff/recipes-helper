import React from "react";
import styles from "./Checkbox.module.css";

type Props = React.PropsWithChildren<
    React.InputHTMLAttributes<HTMLInputElement>
>;

const Checkbox: React.FC<Props> = ({
    children,
    className = "",
    ...checkboxProps
}) => {
    return (
        <label className={styles.checkbox}>
            <input {...checkboxProps} type="checkbox" />
            <span className={styles.checkmark} />
            {!!children ? (
                <span className={styles.label}>&nbsp;{children}</span>
            ) : null}
        </label>
    );
};

export { Checkbox };
