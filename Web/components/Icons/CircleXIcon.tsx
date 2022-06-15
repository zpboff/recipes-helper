import React from 'react';
import { BaseIcon, IconProps } from './BaseIcon';

type Props = IconProps & {
    
};

const CircleXIcon: React.FC<Props> = (props) => {
    return (
        <BaseIcon {...props}>
            <path stroke="none" d="M0 0h24v24H0z" fill="none"></path>
            <circle cx={12} cy={12} r={9}></circle>
            <path d="M10 10l4 4m0 -4l-4 4"></path>
        </BaseIcon>
    )
}

export { CircleXIcon }