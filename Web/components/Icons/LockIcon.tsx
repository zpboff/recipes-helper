import React from "react";
import { BaseIcon, IconProps } from "./BaseIcon";

type Props = IconProps;

const LockIcon: React.FC<Props> = (props) => {
    return (
        <BaseIcon {...props}>
            <path stroke="none" d="M0 0h24v24H0z" fill="none"></path>
            <rect x={5} y={11} width={14} height={10} rx={2}></rect>
            <circle cx={12} cy={16} r={1}></circle>
            <path d="M8 11v-4a4 4 0 0 1 8 0v4"></path>
        </BaseIcon>
    );
};

export { LockIcon };
