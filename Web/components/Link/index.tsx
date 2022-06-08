import React from 'react';
import styles from './Link.module.css';

type Props = React.PropsWithChildren<React.AnchorHTMLAttributes<HTMLAnchorElement> & {    
}>;

const Link: React.FC<Props> = React.forwardRef<HTMLAnchorElement, Props>(({ children, className = "", ...linkProps }, ref) => {
    return (
        <a {...linkProps} className={`${styles.link} ${className}`} ref={ref}>
            {children}
        </a>
    );
});

export {Link}