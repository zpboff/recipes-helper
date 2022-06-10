import React from "react";
import { ComponentMeta, ComponentStory } from "@storybook/react";
import { Input } from "../components/Input";
import { LockIcon } from "../components/Icons";

export default {
    title: "Input",
    component: Input,
    argTypes: {
        icon: {
            table: {
                disable: true,
            },
        },
    },
} as ComponentMeta<typeof Input>;

const Template: ComponentStory<typeof Input> = (args) => (
    <div style={{ width: "400px" }}>
        <Input {...args} />
    </div>
);

export const Basic = Template.bind({});

Basic.args = {
    children: "Placeholder",
    icon: <LockIcon />,
    loading: false,
};
