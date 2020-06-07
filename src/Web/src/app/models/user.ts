import { Role } from './rol';

export class User {
    Id: number;
    UserName: String;
    Email: string;
    Role : Role;
    Permisions : string[];
    Token: string;
}