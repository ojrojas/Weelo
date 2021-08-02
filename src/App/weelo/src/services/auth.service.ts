import jwtDecode from 'jwt-decode';
import StorageService from './storage.service';

class AuthService {
    static isAuthenticated(): boolean {
        const token = StorageService.getSessionToken();
        if (token == null) {
            return false;
        }

        return AuthService.tokenIsValid(token);
    }

    static tokenIsValid(token: any): boolean {
        const decodedToken: any = jwtDecode(token);
        const currentDate = new Date();
        return decodedToken.exp * 1000 > currentDate.getTime();
    }

    static getUserInfo(): any {
        const token = StorageService.getSessionToken();
        if (token != null) {
            return jwtDecode(token);
        }
        return null;
    }
}

export default AuthService;
