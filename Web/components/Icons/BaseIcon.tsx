import clsx from "clsx";
import React, { PropsWithChildren } from "react";
import styles from "./Icon.module.css";

export type IconProps = React.SVGProps<SVGSVGElement>;

const BaseIcon: React.FC<PropsWithChildren<IconProps>> = ({
    children,
    ...svgProps
}) => {
    return (
        <svg
            strokeWidth={2}
            stroke="currentColor"
            fill="none"
            strokeLinecap="round"
            strokeLinejoin="round"
            {...svgProps}
            viewBox="0 0 24 24"
            focusable={false}
            className={clsx(styles.icon, svgProps.className)}
        >
            {children}
        </svg>
    );
};

export { BaseIcon };
