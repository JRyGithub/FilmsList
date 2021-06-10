import React from  'react';
import styled from 'styled-components';
import {Link} from 'react-router-dom';

export const NavBar = () => {
    return (
    <Container>
        <Link to='/signIn'><NavItem>Log Out</NavItem></Link>
    </Container>
    );
}

export default NavBar;

const Container = styled.div`
    width: 100%;
`

const NavItem = styled.div`

`