import React from 'react';
import styles from './Link.module.css';

type Props = React.PropsWithChildren<React.AnchorHTMLAttributes<HTMLAnchorElement> & {
    
}>;

const Link: React.FC<Props> = ({ children, className = "", ...linkProps }) => {
    return (
        <a {...linkProps} className={`${styles.link} ${className}`}>
            {children}
        </a>
    );
};

export {Link}