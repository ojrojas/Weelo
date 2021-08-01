import { combineReducers } from 'redux';
import { UserReducer } from '../reducer/user.reducer';

export const rootReducer = combineReducers({
    users: UserReducer,
  
});

export type AppState = ReturnType<typeof rootReducer>;