import type { NextPage } from 'next'
import Head from 'next/head'
import Image from 'next/image'

const Home: NextPage = () => {
  return (
    <div>
        <Head>
            <title>Create Next App</title>
            <meta name="description" content="Recipes helper" />
            <link rel="icon" href="/favicon.ico" />
        </Head>      
        <header>
            Заголовок
        </header>
        <aside>
            Меню
        </aside>
        <main>
            Контент
        </main>
        <footer>
            Подвал
        </footer>
    </div>
  )
}

export default Home
