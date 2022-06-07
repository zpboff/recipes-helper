import type {NextPage} from 'next'
import Head from 'next/head'
import Image from 'next/image'
import { Container } from '../components/Container'
import { Content } from '../components/Content'
import styles from '../styles/Home.module.css'

const Home: NextPage = () => {
    return (
        <div className={styles.app}>
            <Head>
                <title>Recipes helper</title>
                <meta name="description" content="Recipes helper"/>
                <link rel="icon" href="/favicon.png"/>
            </Head>
            <header className={styles.header}>
            </header>
            <main className={styles.main}>
                <Container>
                    <Content>
                    </Content>
                </Container>
            </main>
        </div>
    )
}

export default Home
