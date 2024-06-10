import '@/shared/ui/globals.css';
import '@/shared/ui/colors.css';

import { PropsWithChildren } from "react";

export default function RootLayout({ children }: PropsWithChildren) {
  return (
    <html lang="ru">
      <body>{children}</body>
    </html>
  )
}
