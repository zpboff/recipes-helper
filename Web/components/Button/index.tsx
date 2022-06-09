import clsx from "clsx";
import React from "react";
import { Loader } from "../Loader";
import styles from "./Button.module.css";

type Size = "small" | "medium" | "large";
type Variant = "default" | "primary" | "success" | "fail" | "warning" | "link";

export type ButtonProps = React.PropsWithChildren<
    React.ButtonHTMLAttributes<HTMLButtonElement> & {
        size?: Size;
        variant?: Variant;
        icon?: React.ReactNode;
        loading?: boolean;
    }
>;

const ButtonLoader = () => (
    <div className={styles.loader}>
        <Loader />
    </div>
);

const Button: React.FC<ButtonProps> = ({
    children,
    size = "medium",
    variant = "primary",
    icon = null,
    loading = false,
    className = "",
    ...buttonProps
}) => {
    return (
        <span
            className={clsx(styles.wrapper, {
                [styles.small]: size === "small",
                [styles.medium]: size === "medium",
                [styles.large]: size === "large",
                [styles.default]: variant === "default",
                [styles.primary]: variant === "primary",
                [styles.success]: variant === "success",
                [styles.negative]: variant === "fail",
                [styles.warning]: variant === "warning",
                [styles.link]: variant === "link",
            })}
        >
            <button
                {...buttonProps}
                disabled={buttonProps.disabled || loading}
                className={clsx(styles.button, className, {
                    [styles.loading]: loading,
                    [styles.withoutIcon]: !icon,
                })}
            >
                {loading && !icon ? <ButtonLoader /> : null}
                <div className={styles.caption}>
                    {!!icon ? (
                        <span className={styles.iconContainer}>
                            <span className={styles.icon}>
                                {loading ? <Loader /> : icon}
                            </span>
                        </span>
                    ) : null}
                    <span className={styles.content}>{children}</span>
                </div>
            </button>
        </span>
    );
};

export { Button };
