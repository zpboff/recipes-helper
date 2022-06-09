import React, { FC } from "react";
import styles from "./Loader.module.css";

type Props = {};

const Loader: FC<Props> = ({}) => {
    return (
        <div className={styles.loader}>
            <div className={styles.segment}></div>
            <div className={styles.segment}></div>
            <div className={styles.segment}></div>
            <div className={styles.segment}></div>
        </div>
    );
};

export { Loader };
