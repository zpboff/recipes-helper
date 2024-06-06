import styles from "./test.module.css";
import cn from "classnames";

type Props = {
    className: string;
}

export function Test({ className }: Props) {
    return <div className={cn(styles.test, className)} />;
}