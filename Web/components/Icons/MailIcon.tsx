import React from "react";
import { BaseIcon, IconProps } from "./BaseIcon";

type Props = IconProps;

const MailIcon: React.FC<Props> = (props) => {
    return (
        <BaseIcon width={16} height={16} {...props} viewBox="0 0 24 24">
            <path stroke="none" d="M0 0h24v24H0z" fill="none"></path>
            <rect x={3} y={5} width={18} height={14} rx={2}></rect>
            <polyline points="3 7 12 13 21 7"></polyline>
        </BaseIcon>
    );
};

export { MailIcon };
