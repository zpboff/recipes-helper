import React from "react";
import { ComponentMeta, ComponentStory } from "@storybook/react";
import { Button } from "../components/Button";
import { MailIcon } from "../components/Icons";

export default {
    title: "Button",
    component: Button,
    argTypes: {
        icon: {
            table: {
                disable: true,
            },
        },
    },
} as ComponentMeta<typeof Button>;

const Template: ComponentStory<typeof Button> = (args) => (
    <>
        <Button {...args} />
        &nbsp;
        <Button {...args} icon={<MailIcon />} />
    </>
);

export const Basic = Template.bind({});

Basic.args = {
    children: "Button",
    variant: "primary",
    size: "medium",
    loading: false,
    disabled: false,
};
