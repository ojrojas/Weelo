import React from 'react';
import Nav from '../navs/Nav';

export const LayoutPage: React.FC = (props?: any) => {
    const { children } = props;
    return (
        <div>
            <Nav pageshow={children} />
        </div>
    );
};
