import React, { PropsWithChildren } from 'react';

type SwitchKey = string | number;

export type SwitchProps = {
    on: SwitchKey;
}

export type CaseProps = {
    when: SwitchKey;
    then: () => React.ReactNode;
}

const Case: React.FC<CaseProps> = ({}) => {
    return (
        <></>
    )
}

const Switch: React.FC<PropsWithChildren<SwitchProps>> = ({ children, on }) => {
    const result = React.Children.toArray(children).map(child => {
        const element = child as React.ReactElement<CaseProps>;

        if(element.props?.when === undefined) {
            return element;
        }

        return element.props.when === on
            ? element.props.then()
            : null;
    });

    return (
        <>{result}</>
    )
}

export { Switch, Case }