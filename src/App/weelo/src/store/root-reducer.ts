import { combineReducers } from 'redux';
import { LoginReducer } from '../reducer/login.reducer';
import { UserReducer } from '../reducer/user.reducer';

export const rootReducer = combineReducers({
    users: UserReducer,
    login: LoginReducer
  
});

export type AppState = ReturnType<typeof rootReducer>;