import '@/shared/globals.css';
import '@/shared/colors.css';

import { PropsWithChildren } from "react";

export default function RootLayout({ children }: PropsWithChildren) {
  return (
    <html lang="ru">
      <body>{children}</body>
    </html>
  )
}
