import type {NextPage} from 'next'
import Head from 'next/head'
import Image from 'next/image'
import styles from '../styles/Home.module.css'

const Home: NextPage = () => {
    return (
        <div className={styles.app}>
            <Head>
                <title>Create Next App</title>
                <meta name="description" content="Recipes helper"/>
                <link rel="icon" href="/favicon.png"/>
            </Head>
            <header className={styles.header}>
                Заголовок
            </header>
            <aside className={styles.aside}>
                Меню
            </aside>
            <main className={styles.main}>
                Контент
            </main>
            <footer className={styles.footer}>
                Подвал
            </footer>
        </div>
    )
}

export default Home
