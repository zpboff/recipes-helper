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
            </header>
            {/*<aside className={styles.aside}>*/}
            {/*    Меню*/}
            {/*</aside>*/}
            <main className={styles.main}>
                Контент
            </main>
        </div>
    )
}

export default Home
