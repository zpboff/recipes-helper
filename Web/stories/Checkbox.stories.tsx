import React from "react";
import { ComponentMeta, ComponentStory } from "@storybook/react";
import { Checkbox } from "../components/Checkbox";

// More on default export: https://storybook.js.org/docs/react/writing-stories/introduction#default-export
export default {
    title: "Checkbox",
    component: Checkbox,
} as ComponentMeta<typeof Checkbox>;

const Template: ComponentStory<typeof Checkbox> = (args) => (
    <div style={{ width: "400px" }}>
        <Checkbox {...args} />
    </div>
);

export const Basic = Template.bind({});

Basic.args = {
    children: "Check",
    disabled: false,
};
