import { applyMiddleware, createStore } from 'redux';
import thunk, { ThunkMiddleware } from 'redux-thunk';
import { composeWithDevTools } from 'redux-devtools-extension';
import { throttle } from 'lodash';
import { rootReducer } from './root-reducer';
import StorageService from '../services/storage.service';

/** State in localstorage * */
const persistedState = StorageService.loadState();

export const store = createStore(
    rootReducer,
    persistedState,
    composeWithDevTools(applyMiddleware(thunk as ThunkMiddleware)),
);

store.subscribe(
    throttle(() => {
        StorageService.saveState({
            ...store.getState(),
        });
    }, 1000),
);
