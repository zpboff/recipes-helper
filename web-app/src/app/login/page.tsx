import { LoginForm } from "@/app/login/LoginForm";

export const metadata = {
    title: 'Вход - Подбор рецептов',
    description: 'Вход',
}

export default function Login() {    
    return (
        <div>
            <h1>Вход</h1>
            <LoginForm />
        </div>
    );
}