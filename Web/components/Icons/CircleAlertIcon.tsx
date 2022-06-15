import React from 'react';
import { BaseIcon, IconProps } from './BaseIcon';

type Props = IconProps & {
    
};

const CircleAlertIcon: React.FC<Props> = (props) => {
    return (
        <BaseIcon {...props}>
            <path stroke="none" d="M0 0h24v24H0z" fill="none"></path>
            <circle cx={12} cy={12} r={9}></circle>
            <line x1={12} y1={8} x2={12} y2={12}></line>
            <line x1={12} y1={16} x2="12.01" y2={16}></line>
        </BaseIcon>
    )
}

export { CircleAlertIcon }