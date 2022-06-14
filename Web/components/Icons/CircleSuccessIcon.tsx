import React from 'react';
import { BaseIcon, IconProps } from './BaseIcon';

type Props = IconProps & {
    
};

const CircleSuccessIcon: React.FC<Props> = (props) => {
    return (
        <BaseIcon width={16} height={16} {...props} viewBox="0 0 24 24">
            <path stroke="none" d="M0 0h24v24H0z" fill="none"></path>
            <circle cx={12} cy={12} r={9}></circle>
            <path d="M9 12l2 2l4 -4"></path>
        </BaseIcon>
    )
}

export { CircleSuccessIcon }