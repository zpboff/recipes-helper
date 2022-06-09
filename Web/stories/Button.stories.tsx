import React from "react";
import { ComponentStory, ComponentMeta } from "@storybook/react";

import { Button } from "../components/Button";

// More on default export: https://storybook.js.org/docs/react/writing-stories/introduction#default-export
export default {
    title: "Button",
    component: Button,
} as ComponentMeta<typeof Button>;

export const Primary = () => <Button variant="primary">Button</Button>;
