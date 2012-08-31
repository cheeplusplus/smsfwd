// SMSFWD by Andrew Koester <andrew@neocodenetworks.com>

package com.neocodenetworks.smsfwd;

import java.security.*;

import javax.crypto.*;
import javax.crypto.spec.*;
import android.util.Log;

public class Crypto {
	public static final String TAG = "smsfwd";
	
	private static Cipher aesCipher;
	private static SecretKey secretKey;
	private static IvParameterSpec ivParameterSpec;
	
	private static String CIPHER_TRANSFORMATION = "AES/CBC/PKCS5Padding";
	private static String CIPHER_ALGORITHM = "AES";
	private static byte[] rawSecretKey = {0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07,
	                                        0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15};
	
	private static String MESSAGEDIGEST_ALGORITHM = "MD5";
	
	public Crypto(String passphrase) {
		byte[] passwordKey = encodeDigest(passphrase);
		
		try {
			aesCipher = Cipher.getInstance(CIPHER_TRANSFORMATION);
		} catch (NoSuchAlgorithmException e) {
			Log.e(TAG, "No such algorithm " + CIPHER_ALGORITHM, e);
		} catch (NoSuchPaddingException e) {
			Log.e(TAG, "No such padding PKCS5", e);
		}
		
		secretKey = new SecretKeySpec(passwordKey, CIPHER_ALGORITHM);
		ivParameterSpec = new IvParameterSpec(rawSecretKey);
	}
	
	public String encryptAsBase64(byte[] clearData) {
		byte[] encryptedData = encrypt(clearData);
		return net.iharder.base64.Base64.encodeBytes(encryptedData);
	}

	public byte[] encrypt(byte[] clearData) {
		try {
			aesCipher.init(Cipher.ENCRYPT_MODE, secretKey, ivParameterSpec);
		} catch (InvalidKeyException e) {
			Log.e(TAG, "Invalid key", e);
			return null;
		} catch (InvalidAlgorithmParameterException e) {
			Log.e(TAG, "Invalid algorithm " + CIPHER_ALGORITHM, e);
			return null;
		}
		
		byte[] encryptedData;
		try {
			encryptedData = aesCipher.doFinal(clearData);
		} catch (IllegalBlockSizeException e) {
			Log.e(TAG, "Illegal block size", e);
			return null;
		} catch (BadPaddingException e) {
			Log.e(TAG, "Bad padding", e);
			return null;
		}
		return encryptedData;
	}
	
	private byte[] encodeDigest(String text) {
		MessageDigest digest;
		try {
			digest = MessageDigest.getInstance(MESSAGEDIGEST_ALGORITHM);
			return digest.digest(text.getBytes());
		} catch (NoSuchAlgorithmException e) {
			Log.e(TAG, "No such algorithm " + MESSAGEDIGEST_ALGORITHM, e);
		}
		
		return null;
	}
}
