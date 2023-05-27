import './globals.css'
import { Header } from "@/app/components/Header";
import { PageContent } from "@/app/components/PageContent/PageContent";
import { Inter } from 'next/font/google'
import { PropsWithChildren } from "react";
import cn from 'classnames';
import styles from './layout.module.scss';

const inter = Inter({ subsets: ['latin'] })

export default function RootLayout({ children }: PropsWithChildren) {
  return (
    <html lang="ru">
      <body className={cn(inter.className, styles.layout)}>
        <Header/>
        <PageContent>{children}</PageContent>               
      </body>
    </html>
  )
}
