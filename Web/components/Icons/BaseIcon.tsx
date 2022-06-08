import React, { PropsWithChildren } from 'react';

export type IconProps = React.SVGProps<SVGSVGElement>;

const defaultSize = 24;
const defaultStrokeWidth = 2;
const defaultStroke = "currentColor";
const defaultFill = "none";
const defaultStrokeLinecap = "round";
const defaultStrokeLinejoin = "round"; 

const BaseIcon: React.FC<PropsWithChildren<IconProps>> = ({ children, ...svgProps }) => {
    const width = svgProps.width ?? svgProps.height ?? defaultSize;
    const height = svgProps.height ?? svgProps.width ?? defaultSize;
    
    return (
        <svg
            xmlns="http://www.w3.org/2000/svg"
            width={width} 
            height={height} 
            viewBox={`0 0 ${width} ${height}`}
            strokeWidth={2}
            stroke="currentColor"
            fill="none"
            strokeLinecap="round"
            strokeLinejoin="round"
            {...svgProps}
        >
            {children}
        </svg>
    );
};

export {BaseIcon}