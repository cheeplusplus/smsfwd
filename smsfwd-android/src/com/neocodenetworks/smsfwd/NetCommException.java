// SMSFWD by Andrew Koester <andrew@neocodenetworks.com>

package com.neocodenetworks.smsfwd;

public class NetCommException extends Exception {
	private static final long serialVersionUID = 1L;
	
	public NetCommException() {
		super();
	}
	
	public NetCommException(String detailMessage) {
		super(detailMessage);
	}
	
	public NetCommException(String detailMessage, Throwable throwable) {
		super(detailMessage, throwable);
	}
}
