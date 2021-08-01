import { AppState } from "../store/root-reducer";

class StorageService {
  private static PRIVATE_KEYS = {
    SESSION_TOKEN: "TOKEN",
  };

  static removeStorageFromLogout(): void {
    const privateStorageKeys = StorageService.PRIVATE_KEYS as any;

    const privateKeys = [privateStorageKeys.SESSION_TOKEN];

    privateKeys.forEach((key) => {
      localStorage.removeItem(key);
    });
  }

  static saveState(state: AppState): void {
    try {
      const serializedState = JSON.stringify(state);
      localStorage.setItem("state", serializedState);
    } catch (e) {
      console.error(e);
    }
  }

  static loadState(): any {
    try {
      const serializedState = localStorage.getItem("state");
      if (serializedState == null) {
        return undefined;
      }
      return JSON.parse(serializedState);
    } catch (e) {
      return undefined;
    }
  }

  static setSessionToken(token: string): void {
    try {
      localStorage.setItem(StorageService.PRIVATE_KEYS.SESSION_TOKEN, token);
    } catch (e) {
      console.error(e);
    }
  }

  static getSessionToken(): string | null {
    try {
      return localStorage.getItem(StorageService.PRIVATE_KEYS.SESSION_TOKEN);
    } catch (e) {
      return null;
    }
  }
}

export default StorageService;
