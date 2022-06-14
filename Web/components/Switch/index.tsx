import React, { PropsWithChildren } from 'react';

export type SwitchProps = {
}

export type CaseProps = {
    when: boolean;
    then: () => React.ReactNode;
}

const Case: React.FC<CaseProps> = ({}) => {
    return (
        <></>
    )
}

const Switch: React.FC<PropsWithChildren<SwitchProps>> = ({ children }) => {
    const result = React.Children.toArray(children).map(child => {
        const element = child as React.ReactElement<CaseProps>;

        if(element.props?.when === undefined) {
            return element;
        }

        return element.props.when
            ? element.props.then()
            : null;
    });

    return (
        <>{result}</>
    )
}

export { Switch, Case }