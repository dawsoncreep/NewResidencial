import { Authorization } from './authorization';

export class User {
    Id: number;
    UserName: string;
    Authorizations : Authorization[];
    Token: string;
}
