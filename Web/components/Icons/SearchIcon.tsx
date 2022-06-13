import React from 'react';
import { BaseIcon, IconProps } from './BaseIcon';

type Props = IconProps & {
    
};

const SearchIcon: React.FC<Props> = (props) => {
    return (
        <BaseIcon width={16} height={16} {...props} viewBox="0 0 24 24">
            <path stroke="none" d="M0 0h24v24H0z" fill="none"></path>
            <circle cx={10} cy={10} r={7}></circle>
            <line x1={21} y1={21} x2={15} y2={15}></line>
        </BaseIcon>
    )
}

export { SearchIcon }