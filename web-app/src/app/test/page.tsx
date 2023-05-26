import { Display } from "@/app/test/components/Display";
import { Input } from "@/app/test/components/Input";
import React from 'react';

type Props = {
    
};

export default function Test({}: Props) {    
    return (
        <>
            <div>Молочко</div>
            <Input />
            <Display />
        </>
    );
}