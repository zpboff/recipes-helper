import React from "react";
import { ComponentMeta, ComponentStory } from "@storybook/react";
import { Button } from "../components/Button";
import { MailIcon } from "../components/Icons";

// More on default export: https://storybook.js.org/docs/react/writing-stories/introduction#default-export
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
    subcomponents: {
        MailIcon,
    },
} as ComponentMeta<typeof Button>;

const Template: ComponentStory<typeof Button> = (args) => <Button {...args} />;

export const Basic = Template.bind({});

Basic.args = {
    children: "Button",
    variant: "primary",
    size: "medium",
    loading: false,
    disabled: false,
};

export const WithIcon = Template.bind({});

WithIcon.args = {
    children: "Button",
    variant: "primary",
    size: "medium",
    loading: false,
    disabled: false,
    icon: <MailIcon />,
};
