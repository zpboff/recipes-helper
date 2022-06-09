import clsx from "clsx";
import React from "react";
import styles from "./Button.module.css";

type Size = "small" | "medium" | "large";
type Variant = "default" | "primary" | "success" | "fail" | "warning" | "link";

type Props = React.PropsWithChildren<
    React.ButtonHTMLAttributes<HTMLButtonElement> & {
        size?: Size;
        variant?: Variant;
        icon?: React.ReactNode;
        loading?: boolean;
    }
>;

const Button: React.FC<Props> = ({
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
            })}
        >
            <button
                {...buttonProps}
                className={clsx(styles.button, className, {
                    [styles.default]: variant === "default",
                    [styles.primary]: variant === "primary",
                    [styles.success]: variant === "success",
                    [styles.fail]: variant === "fail",
                    [styles.warning]: variant === "warning",
                    [styles.link]: variant === "link",
                })}
            >
                <div className={styles.caption}>
                    {!!icon ? (
                        <span className={styles.iconContainer}>
                            <span className={styles.icon}>{icon}</span>
                        </span>
                    ) : null}
                    <span>{children}</span>
                </div>
            </button>
        </span>
    );
};

export { Button };
