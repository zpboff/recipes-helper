import React from 'react';
import { Formik, Form as FormikForm } from 'formik';
import styles from './Form.module.css';

type Props<TValues> = React.PropsWithChildren<{
    defaultValues: TValues;
    onSubmit: (value: TValues) => void;
    className?: string;
}>;

function Form<TValues>({ defaultValues, onSubmit, children, className = "" }: Props<TValues>) {
    return (
        <Formik
            initialValues={defaultValues}
            onSubmit={(values, { setSubmitting }) => {
                onSubmit(values);
                setSubmitting(false);
            }}
        >
            <FormikForm className={`${styles.form} ${className}`}>
                {children}
            </FormikForm>
        </Formik>
    );
};

export {Form}