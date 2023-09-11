# eLedger
*On Development* A simple eLedger to help you budget better

## Generate Certificates And Keys

### Generate symmetric key for refresh token signing
`openssl rand 128 > RefreshTokenSym.key`

### Generate asymmetric key for Access token signing

* Generate Private Key

`openssl ecparam -genkey -name prime256v1 -noout -out AccessTokenAsymCertificate.pem`

* Generate Public Key From Private Key

`openssl ec -in AccessTokenAsymCertificate.pem -pubout -out AccessTokenPublicKey.pem`