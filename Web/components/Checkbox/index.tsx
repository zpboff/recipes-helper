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
        <label className={styles.container}>
            <input {...checkboxProps} type="checkbox" />
            <span className={styles.checkmark} />
            {!!children ? <>&nbsp;{children}</> : null}
        </label>
    );
};

export { Checkbox };
