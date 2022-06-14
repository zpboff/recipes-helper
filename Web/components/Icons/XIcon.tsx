import React from 'react';
import { BaseIcon, IconProps } from './BaseIcon';

type Props = IconProps & {
    
};

const XIcon: React.FC<Props> = (props) => {
    return (
        <BaseIcon width={16} height={16} {...props} viewBox="0 0 24 24">
            <path stroke="none" d="M0 0h24v24H0z" fill="none"></path>
            <line x1={18} y1={6} x2={6} y2={18}></line>
            <line x1={6} y1={6} x2={18} y2={18}></line>
        </BaseIcon>
    )
}

export { XIcon }