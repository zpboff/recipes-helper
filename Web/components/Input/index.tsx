import clsx from "clsx";
import React, { PropsWithChildren, useRef, useState } from "react";
import { useClickOutside } from "../../hooks";
import styles from "./Input.module.css";

type IconPosition = "left" | "right";

type Props = PropsWithChildren<
    React.InputHTMLAttributes<HTMLInputElement> & {
        icon?: React.ReactNode;
        iconPosition?: IconPosition;
        label?: React.ReactNode;
    }
>;

const InputIcon: React.FC<PropsWithChildren> = ({ children }) => (
    <span className={styles.icon}>{children}</span>
);

const Input: React.FC<Props> = ({
    children,
    icon,
    iconPosition = "left",
    label,
    ...inputProps
}) => {
    const ref = useRef<HTMLLabelElement>(null);
    const [focused, setFocused] = useState(false);

    useClickOutside(ref, () => setFocused(false));

    return (
        <label
            className={clsx(styles.input, {
                [styles.leftIcon]: !!icon && iconPosition === "left",
                [styles.rightIcon]: !!icon && iconPosition === "right",
                [styles.active]: focused || !!inputProps.value,
            })}
            htmlFor={inputProps.id}
            onClick={() => setFocused(true)}
            ref={ref}
        >
            {iconPosition === "left" ? <InputIcon>{icon}</InputIcon> : null}
            <input {...inputProps} placeholder="&nbsp;" />
            <span className={styles.label}>{label}</span>
            {iconPosition === "right" ? <InputIcon>{icon}</InputIcon> : null}
        </label>
    );
};

export { Input };
